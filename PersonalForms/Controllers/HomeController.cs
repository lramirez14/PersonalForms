using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalForms.Models;

namespace PersonalForms.Controllers
{
    public class HomeController : Controller
    {
        private PersonalEntities db = new PersonalEntities();
        public ActionResult Index()
        {
            //ViewBag.Title = "Usuarios";
            List<PersonalViewModel> personalList = new List<PersonalViewModel>();
            var users = db.tblPersonal.ToList();
            foreach (var user in users)
            {
                PersonalViewModel personal = new PersonalViewModel();
                personal.Personal_Id = user.Personal_Id;
                personal.Personal_Identification = user.Personal_Identification;
                personal.Personal_FirstName = user.Personal_FirstName;
                personal.Personal_LastName = user.Personal_LastName;
                personal.Personal_Phone = user.Personal_Phone;

                personalList.Add(personal);
            }
            return View(personalList);
        }

        public ActionResult AddUser()
        {

            ViewBag.Title = "Agregar Usuario";

            return View();
        }
        [HttpPost]
        public JsonResult AddUser(PersonalViewModel user)
        {
            string Identification = string.Empty;
            int retorno = 0;
            try
            {
                if (user != null)
                {
                    tblPersonal usr = new tblPersonal();
                    usr = db.tblPersonal.Where(p => p.Personal_Identification == user.Personal_Identification).FirstOrDefault();
                    if (usr == null)
                    {
                        var entity = new tblPersonal
                        {
                            Personal_Id = Guid.NewGuid(),
                            Personal_Identification = user.Personal_Identification,
                            Personal_FirstName = user.Personal_FirstName,
                            Personal_LastName = user.Personal_LastName,
                            Personal_Phone = user.Personal_Phone,
                        };
                        db.tblPersonal.Add(entity);
                        retorno = db.SaveChanges();

                        if (retorno == 1)
                        {
                            retorno = 1;
                        }
                        else
                        {
                            retorno = 0;
                        }
                    }
                    else
                    {
                        retorno = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                Identification = ex.Message;
            }

            return Json(retorno);
        }

        [HttpGet]
        public ActionResult UpdateUser(string Id)
        {
            try
            {
                PersonalViewModel user = new PersonalViewModel();
                if ((Id != null) && (Id != string.Empty))
                {
                    Guid value = new Guid(Id);
                    tblPersonal result = db.tblPersonal.Where(p => p.Personal_Id == value).FirstOrDefault();
                    if (result != null)
                    {
                        user.Personal_Id = result.Personal_Id;
                        user.Personal_Identification = result.Personal_Identification;
                        user.Personal_FirstName = result.Personal_FirstName;
                        user.Personal_LastName = result.Personal_LastName;
                        user.Personal_Phone = result.Personal_Phone;
                        db.Dispose();
                        return View(user);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public JsonResult UpdateUser(PersonalViewModel user)
        {
            int retorno = 2;
            using (var dbo = new PersonalEntities())
            {
                using (var dbPersonal = dbo.Database.BeginTransaction())
                {
                    try
                    {
                        Guid value = new Guid(user.Personal_Id.ToString());
                        tblPersonal result = db.tblPersonal.Where(p => p.Personal_Id == value).FirstOrDefault();
                        if (result == null)
                            return Json(2);
                        else
                        {
                            result.Personal_Identification = user.Personal_Identification;
                            result.Personal_FirstName = user.Personal_FirstName;
                            result.Personal_LastName = user.Personal_LastName;
                            result.Personal_Phone = user.Personal_Phone;

                            dbo.Entry(result).State = System.Data.Entity.EntityState.Modified;
                            retorno= dbo.SaveChanges();
                            if (retorno == 1)
                            {
                                dbPersonal.Commit();
                                return Json(1);
                            }
                            else
                            {
                                return Json(0);
                            }                            
                        }
                    }
                    catch (Exception ex)
                    {
                        dbPersonal.Rollback();
                        return Json(2);
                        throw;
                    }

                }
            }          
}

[HttpGet]
public ActionResult FindUser(string Id)
{
    try
    {
        PersonalViewModel user = new PersonalViewModel();
        if ((Id != null) && (Id != string.Empty))
        {
            Guid value = new Guid(Id);
            tblPersonal result = db.tblPersonal.Where(p => p.Personal_Id == value).FirstOrDefault();
            if (result != null)
            {
                user.Personal_Id = result.Personal_Id;
                user.Personal_Identification = result.Personal_Identification;
                user.Personal_FirstName = result.Personal_FirstName;
                user.Personal_LastName = result.Personal_LastName;
                user.Personal_Phone = result.Personal_Phone;
                db.Dispose();
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        else
        {
            return RedirectToAction("Index");
        }
    }
    catch (Exception ex)
    {
        return RedirectToAction("Index");
    }
}
    }
}