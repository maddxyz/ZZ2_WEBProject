using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WebApplicationThrones.Models;
using System.Collections.Specialized;

namespace WebApplicationThrones.Controllers
{
    public class FightController : Controller
    {

        // GET: Fight
        public async Task<ActionResult> Index()
        {
            List<FightModel> Fights = new List<FightModel>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:11526/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/fight");

                if(response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Fights = JsonConvert.DeserializeObject<List<FightModel>>(temp);
                }
            }
            return View(Fights);
        }
      
        // GET: Fight/Details/5
       /* public ActionResult Details(int id)
        {
            return View();
        }*/

        // GET: Fight/Create
        /*public async Task<ActionResult> Create()
        {
            IEnumerable<HouseModel> list = await (new Controllers.HouseController()).HouseList();
            List<SelectListItem> li = new List<SelectListItem>();
            foreach(HouseModel hm in list)
            {
                li.Add(new SelectListItem() { Text = hm.Name, Value = hm.NumberOfUnits.ToString() });
            }
            ViewBag.HouseList = li;

            return View();
        }*/

        // POST: Fight/Create
        [HttpPost]
        public async Task<ActionResult> Create(FightModel hm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:11526/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    await client.PostAsJsonAsync("api/Fight/Add", hm);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fight/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Fight/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fight/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fight/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}