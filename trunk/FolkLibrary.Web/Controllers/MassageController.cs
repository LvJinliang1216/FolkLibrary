using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Web.Controllers
{
    public class MassageController : Controller
    {
        private readonly ILeaveWordService _leaveWordService;
        public MassageController(ILeaveWordService leaveWordService)
        {
            this._leaveWordService = leaveWordService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMessage(LeaveWordView leaveWord)
        {
            _leaveWordService.Save(leaveWord);
            return RedirectToAction("Index", "Welcome");
        }
    }
}
