using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicantSite.Controllers
{
    public static class ControllerExtensionMethods
    {
        public static void AddSuccessMessage(this TempDataDictionary TempData, string message)
        {
            TempData["SuccessMessage"] = message;
        }

        public static void AddWarningMessage(this TempDataDictionary TempData, string message)
        {
            TempData["WarningMessage"] = message;
        }

        public static void AddErrorMessage(this TempDataDictionary TempData, string message)
        {
            TempData["ErrorMessage"] = message;
        }
    }
}