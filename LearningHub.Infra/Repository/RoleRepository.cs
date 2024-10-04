using Dapper;
using LearningHub.Core.Common;
using System.Data;
using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Core.Repository;

namespace LearningHub.Infra.Repository
{
    public class RoleRepository: IRoleRepository
    {
        private readonly IDbContext _dbContext;
        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Role> GetAllRoles()
        {
            var result = _dbContext.Connection.Query<Role>("Role_Package.GetAllRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Role>("Role_Package.Role_Package",
                p,commandType:CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("RoleName", role.Rolename, dbType: DbType.String,
                direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Role_Package.CreateRole", p,
                commandType: CommandType.StoredProcedure);
            
        }

        public void UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("Id",role.Roleid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("RoleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Role_Package.UpdateRole",p,commandType:CommandType.StoredProcedure);

        }

        public void DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Role_Package.DeleteRole",p,commandType:CommandType.StoredProcedure);
        }
    }
}
