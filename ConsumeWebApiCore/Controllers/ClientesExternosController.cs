using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading.Tasks;
using ConsumeWebApiCore.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ConsumeWebApiCore.Controllers
{
    public class ClientesExternosController : Controller
    {
        //URL donde esta alojada mi api rest
        //public string BaseUrl = "http://localhost/apirestnc/api/clientes";
        public string BaseUrl = "http://localhost:29683/api/clientes";

        // GET: ClientesExternos
        public async Task<ActionResult> Index()
        {
            List<ClientesExternos> ClientesInfo = new List<ClientesExternos>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Consulto los clienets externos
                HttpResponseMessage res = await client.GetAsync("clientes");

                if (res.IsSuccessStatusCode)
                {
                    var ClientExterResponse = res.Content.ReadAsStringAsync().Result;

                    ClientesInfo = JsonConvert.DeserializeObject<List<ClientesExternos>>(ClientExterResponse);

                }

            }

             return View(ClientesInfo);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientesExternos Cliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var PostTask = client.PostAsJsonAsync<ClientesExternos>("clientes", Cliente);
                PostTask.Wait();

                var result = PostTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty,"Error en grabar registro");
            return View(Cliente);
        }

    }
}