using CRM.Common.DBContexts;
using CRM.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Contracts;

public interface IDbService
{
    event Action<UserDto> UserAdded;
    event Action<UserDto> UserRemoved;
    event Action<UserDto> UserUpdated;

    void AddUser(UserDto user);
    UserDto GetUser(int id);
    List<UserDto> GetUsers();
    void UpdateUser(UserDto user);
    void DeleteUser(int id);
}
