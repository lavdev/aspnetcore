﻿using System.Diagnostics.CodeAnalysis;
using StoreOfBuild.Domain;
using System.Threading.Tasks;

namespace StoreOfBuild.Data
{
    public class UnitOfWork : IUnitOfWork   
    {
        private readonly ApplicationDbContext _context;

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
