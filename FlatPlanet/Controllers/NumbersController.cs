using FlatPlanet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatPlanet.Controllers
{
    public class NumbersController : Controller
    {
        NumberContext _context = new NumberContext();

        // GET: Numbers
        public ActionResult Index(int counter = 0)
        {
            @ViewBag.Counter = counter;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Numbers number)
        {
            Numbers item = _context.Numbers.OrderByDescending(x => x.Id).Take(1).FirstOrDefault();

            if (item != null)
            {
                if (item.Counter >= 10)
                {
                    ModelState.AddModelError("", "Counter already reached 10!");
                    @ViewBag.Counter = item.Counter;
                    return View();
                }
                else
                {
                    item.Counter = item.Counter + 1;

                    _context.Numbers.Add(item);
                    _context.SaveChanges();
                    @ViewBag.Counter = item.Counter;
                    return View();
                }
            }

            number.Counter = number.Counter + 1;

            _context.Numbers.Add(number);
            _context.SaveChanges();
            @ViewBag.Counter = number.Counter;
            return View();
        }
    }
}