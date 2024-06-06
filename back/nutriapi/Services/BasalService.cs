using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using nutriapi.Data;
using nutriapi.Models;

namespace nutriapi.Services
{
    public class BasalService
    {
        private readonly ApplicationDbContext _context;

        public BasalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBasalModelAsync(BasalModel model)
        {

            _context.BasalModels.Add(model);
            await _context.SaveChangesAsync();

        }

        public async Task< IEnumerable<BasalModel>> GetBasalModelsAsync()
        {
            return await _context.BasalModels.ToListAsync();
        }
    }
}
