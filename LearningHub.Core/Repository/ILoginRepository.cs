using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface ILoginRepository
    {
        public List<UserData> GetAllUsernamesAndRoles();
        public Login Auth(Login login);
    }
}
