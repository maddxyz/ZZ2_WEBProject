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

        // #################################################################################################
        // M�thodes _****() : Renvoient uniquement les donn�es. Les m�thodes cr�ant des vues appellent ces m�thodes => Economie de code, moins de recopie
        public static async Task<List<FightModel>> _GetFights()
        {
            List<FightModel> Fights = new List<FightModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Fight");

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Fights = JsonConvert.DeserializeObject<List<FightModel>>(temp);
                }
            }
            return Fights;
        }
        public static async Task<FightModel> _GetFight(int ID)
        {
            FightModel Fight = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Fight/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Fight = JsonConvert.DeserializeObject<FightModel>(temp);
                }
            }
            return Fight;
        }
        public static async void _PostFight(FightModel cm)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                await client.PostAsJsonAsync("api/Fight/Add", cm);

            }
        }

        // #################################################################################################
        // M�thodes de vue

        // GET: Fight
        public async Task<ActionResult> Index()
        {
            return View(await _GetFights());
        }


        // GET: Fight/Details/5
         public async Task<ActionResult> Details(int id)
         {
             return View(await _GetFight(id));
         }

        // GET: Fight/Create
        public async Task<ActionResult> Create()
        {
            List<HouseModel> HouseList = await HouseController._GetHouses();
            if (HouseList.Count > 0)
            {
                List<SelectListItem> list = new List<SelectListItem>();
                
                foreach (HouseModel hm in HouseList)
                {
                    list.Add(new SelectListItem() { Text = hm.Name, Value = hm.ID.ToString() });
                }
                ViewBag.HouseList = list;

                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Fight/Create
        [HttpPost]
        public ActionResult Create(FightModel fm)
        {
            try
            {
                _PostFight(fm);
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
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    await client.PostAsJsonAsync("api/Fight/Delete/" + id + "/", (string)null);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
