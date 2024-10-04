using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IRoleService
    {
        public List<Role> GetAllRoles();
        public Role GetRoleById(int id);
        public void CreateRole(Role role);
        public void UpdateRole(Role role);
        public void DeleteRole(int id);
    }
}
