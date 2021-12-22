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
            if(_context.Users.Any(u => u.Email == fromForm.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!");
            }
            if(_context.Users.Any(u => u.Handle == fromForm.Handle))
            {
                ModelState.AddModelError("Handle", "Handle already in use!");
            }
            if(ModelState.IsValid){
                PasswordHasher<User> Haser = new PasswordHasher<User>();
                fromForm.Password = Haser.HashPassword(fromForm, fromForm.Password);
                _context.Add(fromForm);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId",fromForm.UserId);
                return RedirectToAction("Home");
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
                return RedirectToAction("Home");
            }
            return Index();
            
        }
        
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index");
        }
        [HttpGet("home")]
        public IActionResult Home()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if(userId == null)
            {
                return RedirectToAction("Index");
            }

            HomeView renderMe = new HomeView()
            {
                timeLine =new TimeLine(){
                    TLPosts =_context.TextPosts
                    .Include(blah=>blah.Creator)
                    .Include(blah=>blah.LikedBy)
                    .Include(blah=>blah.SharedBy)
                    .OrderByDescending(po=>po.CreatedAt)
                    .ToList()
                },
                SiteUser = _context.Users.FirstOrDefault(us=>us.UserId==userId)
            };
            return View("Home",renderMe);
        }
        [HttpGet("timeline/{id}")]
        public IActionResult TimeLine(int id)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            TimeLineView renderMe = new TimeLineView()
            {
                SiteUser = _context.Users.FirstOrDefault(us=>us.UserId==userId),

            };
            return View("TimeLine",renderMe);
        }
        [HttpPost("post/submit")]
        public IActionResult PostSubmit(HomeView fromForm)
        {
            TextPost NewPost = fromForm.newPost;
            if(ModelState.IsValid)
            {
                if(HttpContext.Session.GetInt32("UserId")==null)
                {
                    ModelState.AddModelError("newPost.Text","gotta be logged in");
                    return Home();
                }
                NewPost.CreatorId = (int)HttpContext.Session.GetInt32("UserId");
                _context.Add(NewPost);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            return Home();
        }
        [HttpGet("user/{id}")]
        public IActionResult UserPage(int id)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            UserPageView renderMe = new UserPageView()
            {
                PageOwner = _context.Users.FirstOrDefault(us=>us.UserId==id),
                follows = _context.Follows.Any(us=>us.FolloweeId==id && us.FollowerId==userId),
                TLPosts = _context.TextPosts.Where(pos=>pos.CreatorId==id)
                    .Include(blah=>blah.Creator)
                    .Include(blah=>blah.LikedBy)
                    .Include(blah=>blah.SharedBy)
                    .OrderByDescending(po=>po.CreatedAt)
                    .ToList(),
                SiteUser = _context.Users.FirstOrDefault(us=>us.UserId==userId)
            };
            //add rts to this eventually
            return View("UserPage", renderMe);
        }
        [HttpGet("follow/{id}")]
        public IActionResult Follow(int id)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            Follow addMe = new Follow()
            {
                FollowerId = userId,
                FolloweeId = id
            };
            _context.Add(addMe);
            _context.SaveChanges();
            return UserPage(id);
        }
        [HttpGet("unfollow/{id}")]
        public IActionResult Unfollow(int id)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            Follow deleteMe = _context.Follows
            .FirstOrDefault(fol=>fol.FollowerId==userId && fol.FolloweeId==id);
            _context.Remove(deleteMe);
            _context.SaveChanges();
            return UserPage(id);
        }
        [HttpGet("changelike/{id}/{from}")]
        public IActionResult ChangeLike(int id, string from)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            if(_context.Likes.Any(li=>li.LikerId==userId&&li.PostId==id))
            {
                return Unlike(id,from);
            }
            return Like(id,from);
        }
        
        [HttpGet("like/{id}/{from}")]
        public IActionResult Like(int id, string from)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            Like newLike = new Like()
            {
                PostId=id,
                LikerId=userId
            };
            _context.Add(newLike);
            _context.SaveChanges();
            return RedirectToAction(from);
        }
        [HttpGet("unlike/{id}/{from}")]
        public IActionResult Unlike(int id, string from)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            Like oldLike = _context.Likes
            .FirstOrDefault(li=>li.PostId==id&& li.LikerId==userId);
            _context.Remove(oldLike);
            _context.SaveChanges();
            return RedirectToAction(from);
        }
        [HttpGet("testroute")]
        public IActionResult TestRoute()
        {
            HttpContext.Session.SetInt32("UserId",1);
            return RedirectToAction("Home");
        }




        
    }
}
