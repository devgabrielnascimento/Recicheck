using APIRecicheck.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRecicheck.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public UserController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
        }

        public IActionResult Index()
        {
            var users = _databaseContext.Users.ToList();
            return View(users);
        }
    }
}
