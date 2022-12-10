using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeklifTalep.Entities;
using TeklifTalep.Entities.DAL;

namespace TeklifTalep.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeklifController : ControllerBase
    {
        private readonly IDbContextFactory<EfContext> _contextFactory;

        public TeklifController(IDbContextFactory<EfContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpGet(Name = "GetTeklifler")]
        [Route("GetTeklifler")]
        public Teklifler Get(int Id)
        {
            var result = new Teklifler();

            using (var db = _contextFactory.CreateDbContext())
                result = db.Teklifler.FromSql($"GetTeklifler {Id}").ToList().FirstOrDefault();

            return result;
        }

        [HttpGet(Name = "ListTeklifler")]
        [Route("ListTeklifler")]
        public IEnumerable<Teklifler> ListTeklif()
        {
            var result = new List<Teklifler>();

            using (var db = _contextFactory.CreateDbContext())
                result = db.Teklifler.FromSql($"ListTeklifler").ToList();

            return result;
        }

        [HttpPost(Name = "InsertTeklifler")]
        [Route("InsertTeklifler")]
        public void Post(Teklifler entity)
        {

            using (var db = _contextFactory.CreateDbContext())
                db.Database.ExecuteSqlRaw("InsertTeklifler @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9", 
                    parameters: new[] { entity.Mod,
                                        entity.HaraketTuru,
                                        entity.Incoterm,
                                        entity.Ulke,
                                        entity.Sehir,
                                        entity.PaketTipi,
                                        entity.Birim1,
                                        entity.Birim2,
                                        entity.ParaBirimi,
                                        entity.Fiyat.ToString() });
        }
    }
}