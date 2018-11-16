using FootballGround.Core.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;


namespace FootballGround.Core
{
    public class FootballGroundDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public FootballGroundDbContext()
            : base("QuanLySanBongEntities")
        {
        }
        public DbSet<Permissions> Permissions { set; get; }
     
        public static FootballGroundDbContext Create()
        {
            return new FootballGroundDbContext();
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            #region Table Main
       
            modelBuilder.Entity<ApplicationUserLogin>().Map(c =>
            {
                c.ToTable("UserLogin");
                c.Properties(p => new
                {
                    p.UserId,
                    p.LoginProvider,
                    p.ProviderKey
                });
            }).HasKey(p => new { p.LoginProvider, p.ProviderKey, p.UserId });

            // Mapping for ApiRole
            modelBuilder.Entity<ApplicationRole>().Map(c =>
            {
                c.ToTable("Role");
                c.Properties(p => new
                {
                    p.Name,
                    p.IsSysAdmin,
                    p.DisplayName                 
                });
            }).HasKey(p => p.Id);
            modelBuilder.Entity<ApplicationRole>().HasMany(c => c.Users).WithRequired().HasForeignKey(c => c.RoleId);

            modelBuilder.Entity<ApplicationUser>().Map(c =>
            {
                c.ToTable("User");              
                c.Properties(p => new
                {
                    p.AccessFailedCount,
                    p.Email,
                    p.EmailConfirmed,
                    p.PasswordHash,
                    p.PhoneNumber,
                    p.PhoneNumberConfirmed,
                    p.TwoFactorEnabled,
                    p.SecurityStamp,
                    p.LockoutEnabled,
                    p.LockoutEndDateUtc,
                    p.UserName,
                    p.FirstName,
                    p.LastName
                });
            }).HasKey(c => c.Id);
            modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Logins).WithOptional().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Claims).WithOptional().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Roles).WithRequired().HasForeignKey(c => c.UserId);

            modelBuilder.Entity<ApplicationUserRole>().Map(c =>
            {
                c.ToTable("UserRole");
                c.Properties(p => new
                {
                    p.UserId,
                    p.RoleId                   
                });
            })
            .HasKey(c => new { c.UserId, c.RoleId });

            modelBuilder.Entity<ApplicationUserClaim>().Map(c =>
            {
                c.ToTable("UserClaim");
                c.Properties(p => new
                {
                    p.UserId,
                    p.ClaimValue,
                    p.ClaimType
                });
            }).HasKey(c => c.Id);

            modelBuilder.Entity<ApplicationRole>().
                HasMany(c => c.Permissions).
                WithMany(p => p.Roles).
                Map(
                    m =>
                    {
                        m.MapLeftKey("RoleId");
                        m.MapRightKey("PermissionId");
                        m.ToTable("RolePermission");
                    });


            #endregion
        }

        public List<T> ExecuteStoredProcedure<T>(string sql, params object[] parameters)
        {
            //add parameters to command
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as SqlParameter;
                    if (p == null)
                        throw new Exception("Not support parameter type");

                    sql += i == 0 ? " " : ", ";

                    sql += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        //output parameter
                        sql += " output";
                    }
                }
            }

            var result = this.Database.SqlQuery<T>(sql, parameters).ToList();
            return result;
        }

        public int ExecuteStoredProcedureNonQuery(string sql, params object[] parameters)
        {
            //return this.Database.ExecuteSqlCommand(sql, parameters);

            //var connection = context.Connection;
            var connection = this.Database.Connection;
            //Don't close the connection after command execution

            //open the connection for use
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                // move parameters to command object
                if (parameters != null)
                    foreach (var p in parameters)
                        cmd.Parameters.Add(p);

                //database call
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
