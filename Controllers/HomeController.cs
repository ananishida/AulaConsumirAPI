using AulaConsumirAPicerto.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AulaConsumirAPicerto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Pessoas()
        {
            string BaseUrl = "http://localhost:59130/";

            List<Pessoa> pessoas = new List<Pessoa>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));
            HttpResponseMessage response = await client.GetAsync("api/pessoas");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(dados);
            }
            return View(pessoas);
        }
        public async Task<ActionResult> PessoasId(int id)
        {
            string BaseUrl = "http://localhost:59130/";
            Pessoa? p = new Pessoa();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));

            HttpResponseMessage response = await client.GetAsync("api/pessoas" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<Pessoa>(dados);
            }
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Pessoa p)
        {
            string BaseUrl = "http://localhost:59130/";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(BaseUrl + "api/pessoas",p);

            return RedirectToAction("pessoas");

        }
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }
        public async Task<IActionResult> Alterar()
        {
            return View();

        }
        public async Task<IActionResult> Excluir()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Alterar(Pessoa p, int id)
        {
            string BaseUrl = "http://localhost:59130/";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/pessoas/"+ id, p);

            return RedirectToAction("pessoas");
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            string BaseUrl = "http://localhost:59130/";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/pessoas/" + id);

            return RedirectToAction("pessoas");
        }
    }
}
