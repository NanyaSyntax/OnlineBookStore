using Microsoft.AspNetCore.Identity;
using OnlineBookStore.Data.DTO;
using OnlineBookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Core.IService
{
    public interface IUserService
    {
        Task<IdentityResult> AddUserAsync(User user);
    }
}
