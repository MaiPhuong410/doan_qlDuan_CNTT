using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_qlDuan_CNTT.Areas.Admin.Models;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace doan_qlDuan_CNTT.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        AdminDataContext db = new AdminDataContext();

        private static byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        private static byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        public string Encrypt(string str)
        {
            byte[] textbyte = Encoding.UTF8.GetBytes(str);
            RijndaelManaged rm = new RijndaelManaged();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, rm.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(textbyte, 0, textbyte.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Login(Models.AccountAdmin adLogin)
        {
            try
            {
                adLogin.Password = Encrypt(adLogin.Password);
                if (!db.AccountAdmins.Where(a=>a.UserName==adLogin.UserName).Count().Equals(0))
                {
                    if (!db.AccountAdmins.Where(a => a.UserName == adLogin.UserName && a.Password == adLogin.Password).Count().Equals(0))
                    {
                        var user_login = db.AccountAdmins.Where(a => a.UserName == adLogin.UserName && a.Password == adLogin.Password).First();
                        Session["Username"] = user_login.UserName;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session["Username"] = null;
                        ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
                    }
                }
                else
                {
                    Session["Username"] = null;
                    ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
                }
            }
            catch (Exception)
            {
                Session["Username"] = null;
                ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
            }
            return View();
        }

        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session["UserName"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}