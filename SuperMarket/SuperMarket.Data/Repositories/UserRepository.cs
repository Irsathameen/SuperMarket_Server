using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SuperMarket.Context;
using SuperMarket.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SuperMarketDbContext _context;

        public UserRepository(SuperMarketDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ValidateUserAsync(string username, string password)
        {
          
         return await _context.Users.Where(u => u.Username == username && u.PasswordHash == password).FirstOrDefaultAsync() != null;      

        }
    }
}
