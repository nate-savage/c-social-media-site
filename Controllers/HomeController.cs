using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost("user/submit")]
        public IActionResult UserSubmit(User fromForm)
        {
            if(ModelState.IsValid){
                if(_context.Users.Any(u => u.Email == fromForm.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return Index();
                }
                PasswordHasher<User> Haser = new PasswordHasher<User>();
                fromForm.Password = Haser.HashPassword(fromForm, fromForm.Password);
                _context.Add(fromForm);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId",fromForm.UserId);
                return RedirectToAction("Dashboard");
            }
            return Index();
        }

        [HttpPost("login/submit")]
        public IActionResult LoginSubmit(Login fromForm)
        {
            if(ModelState.IsValid)
            {
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == fromForm.LogEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                    return Index();
                }
                var hasher = new PasswordHasher<Login>();
                
                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(fromForm, userInDb.Password, fromForm.LogPassword);
                
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                    return Index();
                }
                HttpContext.Session.SetInt32("UserId",userInDb.UserId);
                //send them to the dashbaord
                return RedirectToAction("Dashboard");
            }
            return Index();
            
        }
        
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index");
        }



        
    }
}
