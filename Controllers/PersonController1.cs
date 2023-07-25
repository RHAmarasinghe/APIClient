using APIClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace APIClient.Controllers
{
    public class PersonController1 : Controller
    {
        Uri baseAddress = new Uri("https://64bf48d65ee688b6250d3b7f.mockapi.io/api/test");
        private readonly HttpClient _client;

        public PersonController1() 
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<PersonViewModel> personlist = new List<PersonViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress
                + "/Person").Result;

            if (response.IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                personlist = JsonConvert.DeserializeObject<List<PersonViewModel>>(data);
            }

            return View();
        }
    }
}
