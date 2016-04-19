using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace GearUp.Models
{
    public class DbHelper
    {
        private AdminEntities db = new AdminEntities();
        private ApplicationUserManager _userManager;

        public IEnumerable<AspNetRole> getRoles(String id)
        {
            return db.AspNetRoles;
        }

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}
    }
}