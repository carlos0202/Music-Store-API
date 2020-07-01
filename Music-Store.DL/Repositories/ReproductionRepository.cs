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
    public class ReproductionRepository : IRepository<Reproduction, long>
    {
        private readonly MusicStoreContext _context;

        public ReproductionRepository(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<Reproduction> FindById(long Id)
        {
            return await _context.Reproductions.FindAsync(Id);
        }

        public async Task<IEnumerable<Reproduction>> GetAll()
        {
            return await _context.Reproductions.ToListAsync();
        }

        public async Task<IEnumerable<Reproduction>> Where
            (Expression<Func<Reproduction, bool>> exp)
        {
            return await _context.Reproductions.AsQueryable().Where(exp).ToListAsync();
        }
    }
}
