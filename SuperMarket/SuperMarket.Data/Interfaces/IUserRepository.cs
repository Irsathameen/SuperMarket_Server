using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ValidateUserAsync(string username, string password);
    }
}
