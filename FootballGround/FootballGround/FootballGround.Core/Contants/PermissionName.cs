using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGround.Core.Contants
{
   public static class NamePermission
    {
        public const string UserManger = "FootballGround.UserManger";

        public const string RoleManger = "FootballGround.RoleManger";
        public const string UpdateRoles = "FootballGround.UpdateRoles";
        public const string DeleteRoles = "FootballGround.DeleteRoles";
        public const string AddRoles    = "FootballGround.AddRoles";

    }
    public static class DisplayName
    {
        public const string RoleManger = "Quản lý vai trò";
        public const string UpdateRoles = "Cập nhật người dùng";
        public const string DeleteRoles = "Xóa vai trò";
        public const string AddRoles = "Thêm mới vai trò";
    }
}
