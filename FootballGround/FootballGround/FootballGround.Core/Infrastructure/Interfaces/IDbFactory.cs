using FootballGround.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Core.Infrastructure.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        FootballGroundDbContext Init();
    }
}
