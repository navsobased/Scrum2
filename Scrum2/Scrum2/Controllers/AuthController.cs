
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;

namespace Scrum2.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Datalayer.Models.User model)
        {
            if (!ModelState.IsValid) //Checks if input fields have the correct format
            {
                return View(model); //Returns the view with the input values so that the user doesn't have to retype again
            }
            using (var db = new Datalayer.Models.DatabaseContext())
            {
                if (db.Users.FirstOrDefault(u => u.Email == model.Email) != null) //Checks if email exists in database
                {

                    var getPassword = db.Users.Where(u => u.Email == model.Email).Select(u => u.Password);
                    var materializePassword = getPassword.ToList();
                    var password = materializePassword[0];




                    if (model.Email != null && model.Password == password)

                    {
                        var getName = db.Users.Where(u => u.Email == model.Email).Select(u => u.FirstName);
                        var materializeName = getName.ToList();
                        var name = materializeName[0];



                        var getEmail = db.Users.Where(u => u.Email == model.Email).Select(u => u.Email);
                        var materializeEmail = getEmail.ToList();
                        var email = materializeEmail[0];

                        var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, name),
                        new Claim(ClaimTypes.Email, email),

                },
                            "ApplicationCookie");

                        var ctx = Request.GetOwinContext();
                        var authManager = ctx.Authentication;
                        authManager.SignIn(identity);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
                ModelState.AddModelError("", "Invalid email or password");
                return View(model); //Should always be declared on the end of an action method
            }


        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registration(Datalayer.Models.User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Datalayer.Models.DatabaseContext())
                {

                    var user = db.Users.Create();
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Signature = model.Signature;
                    user.Telephone = model.Telephone;
                    user.Password = model.Password;
                    user.UserId = model.UserId;


                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            else
            {
                ModelState.AddModelError("", "One or more fields have been");
            }
            return View();
        }
    }


}