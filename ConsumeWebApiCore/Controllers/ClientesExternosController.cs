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

                //METODO QUE CONUSLTE DIRECCIONES
                

            }

             return View(ClientesInfo);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientesExternos NewCliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                //debo colocar el nombre del controller a aplicar el verbo post
                var PostTask = client.PostAsJsonAsync<ClientesExternos>("clientes", NewCliente);
                PostTask.Wait();

                var result = PostTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty,"Error en grabar registro");
            return View(NewCliente);
        }


        public ActionResult Edit(int id)
        {
            ClientesExternos clientes = null;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(BaseUrl);

                var responseTask = client.GetAsync("clientes/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClientesExternos>();
                    readTask.Wait();
                    clientes = readTask.Result;
                }

            }
            return View(clientes);
        }

        [HttpPost]
        public ActionResult Edit(ClientesExternos EditCliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                
                var PutTask = client.PutAsJsonAsync<ClientesExternos>("clientes", EditCliente);
                PutTask.Wait();

                var result = PutTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error en actualizar registro");
            return View(EditCliente);
        }


        public ActionResult Delete(int id)
        {
            ClientesExternos clientes = null;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(BaseUrl);

                var responseTask = client.GetAsync("clientes/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClientesExternos>();
                    readTask.Wait();
                    clientes = readTask.Result;
                }

            }
            return View(clientes);
        }

        [HttpPost]
        public ActionResult Delete(ClientesExternos EditCliente, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                //var DeltTask = client.DeleteAsync("clientes/" + id.ToString());
                var DeltTask = client.DeleteAsync("clientes/" + EditCliente.IdCliente.ToString());
                DeltTask.Wait();

                var result = DeltTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error en actualizar registro");
            return View(EditCliente);
        }

    }
}