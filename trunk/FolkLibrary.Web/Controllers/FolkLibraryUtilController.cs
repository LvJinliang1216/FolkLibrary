using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Util;

namespace FolkLibrary.Web.Controllers
{
    public class FolkLibraryUtilController : Controller
    {
        //
        // GET: /FolkLibraryUtil/

        public ActionResult ValidateCode()
        {
            int width = 100;
            int height = 40;
            int fontsize = 20;
            string code = string.Empty;
            byte[] bytes = FolkLibrary.Util.ValidateCode.CreateValidateGraphic(out code, 4, width, height, fontsize);
            SessionHelper.SetValidateCode(Session, code);
            return File(bytes, @"image/jpeg");
        }

    }
}
