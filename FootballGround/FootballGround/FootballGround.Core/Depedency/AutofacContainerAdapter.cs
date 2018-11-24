using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballGround.Core.Depedency
{
  public class AutofacContainerAdapter : ContainerBuilder,IResolveDependencies, IRegisterDependencies
    {
        private ContainerBuilder _builder;
        private IContainer _container;
        private bool _isBuilderChanged;
        private bool _hasBuildContainer;

        public IContainer ContainerInstance
        {
            get
            {
                if (_container == null)
                {
                    _container = Builder.Build();
                    _hasBuildContainer = true;
                }
                else
                {
                    if (_isBuilderChanged)
                    {
                        Builder.Update(_container);
                        _isBuilderChanged = false;
                        _hasBuildContainer = true;
                    }
                }
                return _container;
            }
        }

        public ContainerBuilder Builder
        {
            get
            {
                if (_builder == null || _hasBuildContainer)
                {
                    _builder = new ContainerBuilder();
                    _isBuilderChanged = true;
                    _hasBuildContainer = false;
                }
                return _builder;
            }
        }

        public void RegisterInstance<TInterface>(TInterface instance) where TInterface : class
        {
            Builder.RegisterInstance(instance);
        }

        public void RegisterInstanceNamed<TInterface>(TInterface instance, string name) where TInterface : class
        {
            Builder.RegisterInstance(instance).Named<TInterface>(name);
        }

        public T Resolve<T>()
        {
            return ContainerInstance.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            return ContainerInstance.ResolveNamed<T>(name);
        }

        public T ResolveOptional<T>() where T : class
        {
            return ContainerInstance.ResolveOptional<T>();
        }

        public T ResolveOptional<T>(string name) where T : class
        {
            return ContainerInstance.ResolveOptionalNamed<T>(name);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return ContainerInstance.Resolve<IEnumerable<T>>();
        }

        public object Resolve(Type type)
        {
            return ContainerInstance.Resolve(type);
        }

        public object Resolve(Type type, string name)
        {
            return ContainerInstance.ResolveNamed(name, type);
        }

        public object ResolveOptional(Type type)
        {
            return ContainerInstance.ResolveOptional(type);
        }

        public object ResolveOptional(Type type, string name)
        {
            object result;
            if (ContainerInstance.TryResolveNamed(name, type, out result))
            {
                return result;
            }
            return null;
        }

        public void RegisterHub<TType>()
        {
            Builder.RegisterType<TType>().ExternallyOwned();
        }
        public void Register(Type type, params DependencyParameter[] parameters)
        {
            var register = Builder.RegisterType(type);
            if (parameters.Length > 0)
            {
                register.WithParameters(parameters.Select(p => new NamedParameter(p.Key, p.Value)));
            }
        }

        public void Register<TFrom, TTo>(params DependencyParameter[] parameters) where TTo : TFrom
        {
            var register = Builder.RegisterType<TTo>().As<TFrom>();
            if (parameters.Length > 0)
            {
                register.WithParameters(parameters.Select(p => new NamedParameter(p.Key, p.Value)));
            }
        }
    }
}
