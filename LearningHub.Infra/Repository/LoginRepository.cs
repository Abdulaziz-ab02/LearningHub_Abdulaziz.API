using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.DTO;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Core.Repository;
using LearningHub.Core.Data;

namespace LearningHub.Infra.Repository
{
    public class LoginRepository: ILoginRepository
    {
        private readonly IDbContext _dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<UserData> GetAllUsernamesAndRoles()
        {
            var result = _dbContext.Connection.Query<UserData>("GetUesrRoleName",
                commandType:CommandType.StoredProcedure);
            return result.ToList();
        }
        public Login Auth(Login login)
        {
            var p = new DynamicParameters();
            p.Add("USER_NAME",login.Username,dbType:DbType.String,
                direction:ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String,
                direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Login>("Login_Package.User_Login",p,
                commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
