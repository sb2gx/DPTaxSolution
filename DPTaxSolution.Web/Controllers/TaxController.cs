using DPTaxSolution.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DPTaxSolution.Web.Controllers
{
    public class TaxController : Controller
    {
        private readonly HttpClient _httpClient;

        public TaxController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("TaxApi");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/tax/");
            response.EnsureSuccessStatusCode();

            var taxRecords = await response.Content.ReadAsAsync<IEnumerable<TaxRecord>>();
            return View(taxRecords);
        }

        [HttpGet]
        public IActionResult CalculateTax()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateTax(decimal amount, TaxCalculationType calculationType)
        {
            var request = new
            {
                Amount = amount,
                CalculationType = calculationType
            };

            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/tax/calculate", content);
            response.EnsureSuccessStatusCode();

            var calculatedTax = await response.Content.ReadAsAsync<decimal>();
            // Display the result or save to database, etc.
            // ...

            return RedirectToAction("Index");
        }
    }
}
