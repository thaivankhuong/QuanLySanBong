using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Core.Depedency
{
    public interface IRegisterDependencies
    {
        void Register(Type type, params DependencyParameter[] parameters);

        void Register<TFrom, TTo>(params DependencyParameter[] parameters) where TTo : TFrom;
    }
}
