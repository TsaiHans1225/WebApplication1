using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using WebApplication1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {


        private readonly MvcUserDbContext Home_db;

        public HomeController(MvcUserDbContext _db)
        {
            Home_db = _db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public Dictionary<string, string> Index2()
        {
            var result = new Dictionary<string, string>()
            {
                {"key1", "Banana"},
                {"key2", "Apple"},
                {"key3", "Orange"}
            };
            return result;
        }

        public IEnumerable<Class1> Index3(string Name, int Id, int Sal)
        {
            if (Sal <= 100)
            {
                Sal = 101;
            }

            List<Class1> class1s = new List<Class1>();
            {
                class1s.Add(new Class1() { Id = 9527, Name = "柴柴", Sal = 30000 });
                class1s.Add(new Class1() { Id = 9528, Name = "周星星", Sal = 878787 });
                class1s.Add(new Class1() { Id = 9526, Name = "哈士奇", Sal = 6666 });
                class1s.Add(new Class1() { Id = Id, Name = Name, Sal = Sal });
                class1s.Add(new Class1() { Id = Id, Name = Name, Sal = Sal });
                class1s.Add(new Class1() { Id = Id, Name = Name, Sal = Sal });
                class1s.Add(new Class1() { Id = Id, Name = Name, Sal = Sal });
                class1s.Add(new Class1() { Id = Id, Name = Name, Sal = Sal });
            }
            return class1s;
        }
        public IEnumerable<Models.UserTable> Index4()
        {
            var TEST = from a in Home_db.UserTables
                       //where a.UserSex == "F"
                       select a;
            return TEST;
        }


        public IActionResult insert(string name)
        {
            UserTable user = new UserTable();
            user.UserName = name;
            user.UserSex = "F";
            user.UserMobilePhone = "091122334";
            user.UserBirthDay = DateTime.Now;
            Home_db.Add(user);
            Home_db.SaveChanges();
            return View();
        }

        public IActionResult update(int uid, string name)
        {
            var TEST = from a in Home_db.UserTables
                       where a.UserId == uid
                       select a;
            foreach (UserTable user in TEST)
            {
                user.UserName = name;
                user.UserSex = "F";
                user.UserBirthDay = DateTime.Now;
            }

            Home_db.SaveChanges();
            return View();
        }

    }
}