using Microsoft.AspNetCore.Mvc;
using TeklifTalep.Entities.DAL;

namespace TeklifTalep.Controllers
{
    public class TeklifController : Controller
    {
        private readonly string BaseUrl = "https://localhost:7277/Teklif/";

        public async Task<IActionResult> Index()
        {
            var result = new List<Teklifler>();
            using (var client = new HttpClient())
            {
                var response = await client.GetFromJsonAsync(
                                                BaseUrl + "ListTeklifler", typeof(List<Teklifler>));

                result = response as List<Teklifler>;

            }


            return View(result);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var result = new Teklifler();
            using (var client = new HttpClient())
            {
                var response = await client.GetFromJsonAsync(
                                                BaseUrl + "GetTeklifler?Id=" + id.ToString(), typeof(Teklifler));

                result = response as Teklifler;

            }


            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Teklif/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mod,HaraketTuru,Incoterm,Ulke,Sehir,PaketTipi,Birim1,Birim2,ParaBirimi,Fiyat")] Teklifler teklif)
        {
            if (ModelState.IsValid)
            {   
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                                                    BaseUrl + "InsertTeklifler", teklif);


                }


                    return RedirectToAction(nameof(Index));
            }
            return View(teklif);
        }


    }
}
