using BookStoreApplication.Data;
using BookStoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Repository
{
    public class LanguageRepository
    {
        private readonly BookContext _context = null;
        public LanguageRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();

        }
    }
}
