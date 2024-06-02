using _CellPhoneService_.Entity;
using _CellPhoneService_.Model.Services;

namespace _CellPhoneService_.Controller
{
    public enum RoleStatus
    {
        MANAGER,
        USER
    }

    public static class RoleHelper
    {
        public static RoleStatus GetRole(string role)
        {
            return role == "MANAGER" ? RoleStatus.MANAGER : RoleStatus.USER;
        }
    }



    public class RoleController
    {
        RoleService roleService = new RoleService();

        public Instance<List<Roles>> getRoles()
        {
            return roleService.getRoles();
        }

        public Instance<RoleStatus> getRole(int id)
        {
            return roleService.getRole(id);
        }
    }
}
