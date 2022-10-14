using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.Controllers
{
    public class HomeController : Controller
    {

      private readonly FactoryContext _db;

      public HomeController(FactoryContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Login()
      {
        return View();
      }

      public ActionResult Index()
      {
        return View();
      }
    }
}