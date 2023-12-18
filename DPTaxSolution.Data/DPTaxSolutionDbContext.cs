using DPTaxSolution.Core.Entities;
using DPTaxSolution.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPTaxSolution.Data
{
    public class DPTaxSolutionDbContext: DbContext
    {
        public DbSet<TaxRecord> TaxRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LocalDB");
        }
    }
}
