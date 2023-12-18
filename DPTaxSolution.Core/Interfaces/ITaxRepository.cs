using DPTaxSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPTaxSolution.Core.Interfaces
{
    public interface ITaxRepository
    {
        IEnumerable<TaxRecord> GetAllTaxRecords();
        TaxRecord GetTaxRecordById(int id);
        void AddTaxRecord(TaxRecord taxRecord);
        void UpdateTaxRecord(TaxRecord taxRecord);
        void DeleteTaxRecord(int id);
    }
}
