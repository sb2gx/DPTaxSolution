using DPTaxSolution.Core.DTO;
using DPTaxSolution.Core.Entities;
using DPTaxSolution.Core.Interfaces;
using DPTaxSolution.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace DPTaxSolution.Web.Pages
{
    public class CalculateTaxModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CalculateTaxModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public TaxRecord TaxRecord { get; set; }

        public List<TaxRecord> TaxRecords { get; set; } = new List<TaxRecord>();

        public IActionResult OnGet()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var httpClient = _httpClientFactory.CreateClient("TaxApi");

            var jsonRequest = JsonConvert.SerializeObject(TaxRecord);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/tax", content);

            if (response.IsSuccessStatusCode)
            {
                var calculatedTax = await response.Content.ReadAsStringAsync();
                TempData["CalculatedTax"] = calculatedTax;
                return RedirectToPage(); // Redirect to a different page after successful calculation
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error calculating tax. Please try again.");
                return Page();
            }
        }
    }
}
