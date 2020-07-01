using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.Models;
using Music_Store.DL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MusicStoreContext _context;

        public UserRepository(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Users.CountAsync();
        } 
    }
}
