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
    public class TaxRepository : ITaxRepository
    {
        private readonly DPTaxSolutionDbContext _dbContext;
        
        public TaxRepository(DPTaxSolutionDbContext dbContext) 
        { 
            _dbContext = dbContext; 
        }

        public void AddTaxRecord(TaxRecord taxRecord)
        {
            _dbContext.TaxRecords.Add(taxRecord);
            _dbContext.SaveChanges();
        }

        public void DeleteTaxRecord(int id)
        {
            _dbContext.TaxRecords.Remove(GetTaxRecordById(id));
            _dbContext.SaveChanges();
        }

        public IEnumerable<TaxRecord> GetAllTaxRecords()
        {
            return _dbContext.TaxRecords;
        }

        public TaxRecord GetTaxRecordById(int id)
        {
            return _dbContext.TaxRecords.Where(t => t.Id == id).FirstOrDefault();
        }

        public void UpdateTaxRecord(TaxRecord taxRecord)
        {
            _dbContext.Update(taxRecord);
        }
    }
}
