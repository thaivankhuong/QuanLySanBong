using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballGround.Core.Infrastructure.Interfaces;
using FootballGround.Core.Model;

namespace FootballGround.Core.Infrastructure.ImplementInterfaces
{
    public class DbFactory : Disposable, IDbFactory
    {
        private FootballGroundDbContext dbContext;

        public FootballGroundDbContext Init()
        {
            return dbContext ?? (dbContext = new FootballGroundDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

      
    }
}
