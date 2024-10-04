using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using LearningHub.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public List<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
        public Role GetRoleById(int id)
        {
           return _roleRepository.GetRoleById(id);
        }
        public void CreateRole(Role role)
        {
            _roleRepository.CreateRole(role);
        }
        public void UpdateRole(Role role)
        {
            _roleRepository.UpdateRole(role);
        }
        public void DeleteRole(int id)
        {
            _roleRepository.DeleteRole(id);
        }
    }
}
