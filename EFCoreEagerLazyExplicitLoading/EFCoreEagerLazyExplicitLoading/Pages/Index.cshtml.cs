using EFCoreEagerLazyExplicitLoading.DBContext;
using EFCoreEagerLazyExplicitLoading.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEagerLazyExplicitLoading.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDBContext _db;
        public IEnumerable<Villa> Villas { get; set; }
        public int TotalVillas { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            //Eager Loading
            //Automatically load the data based on foregin & primary key relations
            List<Villa> eager_villas = _db.Villas.Include(x => x.VillaAmenities).ToList();

            //Lazy Loading
            Villas = _db.Villas.ToList(); //this is lazy loading
            TotalVillas = Villas.Count(); //here hit the database & load the data
            foreach(var villa in Villas)
            {
                villa.VillaAmenities = _db.VillaAmenities.Where(x=>x.VillaId == villa.Id).ToList();
            }

            //Explicit Loading
            Villa? explicitVilla = _db.Villas.FirstOrDefault(x => x.Id == 1);
            //here load multiple items so used Collection(), for many to many
            _db.Entry(explicitVilla).Collection(u => u.VillaAmenities).Load();

            var villaAmenitie = _db.VillaAmenities.FirstOrDefault(x => x.Id == 1);
            //here load single item so used Reference(),for one to many
            _db.Entry(villaAmenitie).Reference(x => x.Villa).Load();
        }
    }
}