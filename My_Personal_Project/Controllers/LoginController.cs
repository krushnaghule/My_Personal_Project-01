using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Personal_Project.Data;
using My_Personal_Project.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace My_Personal_Project.Controllers
{
    public class LoginController : Controller
    {
        public readonly ApplicationDbContext Context;

        public LoginController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            ViewBag.IsIndexView = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPage(LoginModel model)
        {

            var userinfo = await Context.Login
                .FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);

            if (userinfo == null)
            {
                ViewBag.ErrorMessage = "Invalid email or password";
                return View(model);
            }

            return RedirectToAction("HomePage", "Home");
        }




        [HttpGet]
        public IActionResult RegistrationPage()
        {
            ViewBag.IsIndexView = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPage(LoginModel model)
        {
            var userinfo = new LoginModel
            {
                First_Name = model.First_Name,
                Last_Name = model.Last_Name,
                Phone = model.Phone,
                Email = model.Email,
                Password = model.Password,
                Confirm_Password = model.Confirm_Password
            };
            await Context.Login.AddAsync(userinfo);
            await Context.SaveChangesAsync();
            return RedirectToAction("LoginPage", "Login");
        }

    }
}
