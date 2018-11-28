
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Common.Permission
{
    public class PermissionApplication : IPermissionApplication
    {

        public IEnumerable<PermissionProvider> GetPermissions()
        {
            var userManger = new PermissionProvider
            {
                DisplayName ="Quản lý người dùng",
                PermissionName = NamePermission.UserManger
            };

            var deleteRoles = new PermissionProvider
            {
                DisplayName = "Xóa vai trò",
                PermissionName = NamePermission.DeleteRoles
            };

            var addNewRole = new PermissionProvider
            {
                DisplayName = "Thêm mới vai trò",
                PermissionName = NamePermission.AddRoles
            };

            var updateRole = new PermissionProvider
            {
                DisplayName = "Cập nhật vai trò",
                PermissionName = NamePermission.UpdateRoles
            };

            var roleManger= new PermissionProvider
            {
                DisplayName = "Quản lý vai trò",
                PermissionName = NamePermission.RoleManger,
                ImpliedBy = new List<PermissionProvider>
                {
                    addNewRole,
                    updateRole,
                    deleteRoles
                }
                
            };


            return new PermissionProvider[] { userManger,
                                              roleManger };
        }
      
    }
}
