using DPTaxSolution.Core.DTO;
using DPTaxSolution.Core.Entities;
using DPTaxSolution.Core.Interfaces;
using DPTaxSolution.Core.Strategy;
using Microsoft.AspNetCore.Mvc;

namespace DPTaxSolution.API.Controllers
{
    [ApiController]
    [Route("api/tax")]
    public class TaxApiController : ControllerBase
    {
        private readonly ITaxCalculatorService _taxCalculatorService;
        private readonly ITaxRepository _taxRepository;

        public TaxApiController(ITaxCalculatorService taxCalculatorService, ITaxRepository taxRepository)
        {
            _taxCalculatorService = taxCalculatorService;
            _taxRepository = taxRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaxRecord>> GetAllTaxRecords()
        {
            var taxRecords = _taxRepository.GetAllTaxRecords();
            return Ok(taxRecords);
        }

        [HttpGet("{id}")]
        public ActionResult<TaxRecord> GetTaxRecordById(int id)
        {
            var taxRecord = _taxRepository.GetTaxRecordById(id);
            if (taxRecord == null)
                return NotFound();

            return Ok(taxRecord);
        }

        [HttpPost]
        public IActionResult AddTaxRecord([FromBody] TaxRecord taxRecord)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            taxRecord.SetStrategy();
            _taxRepository.AddTaxRecord(taxRecord);
            return CreatedAtAction(nameof(GetTaxRecordById), new { id = taxRecord.Id }, taxRecord);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaxRecord(int id, [FromBody] TaxRecord taxRecord)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRecord = _taxRepository.GetTaxRecordById(id);
            if (existingRecord == null)
                return NotFound();

            _taxRepository.UpdateTaxRecord(taxRecord);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaxRecord(int id)
        {
            var existingRecord = _taxRepository.GetTaxRecordById(id);
            if (existingRecord == null)
                return NotFound();

            _taxRepository.DeleteTaxRecord(id);
            return NoContent();
        }

    }

}
