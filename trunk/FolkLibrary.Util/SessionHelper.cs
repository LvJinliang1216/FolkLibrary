using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FolkLibrary.Util
{
    public class SessionHelper
    {
        public static void SetValidateCode(HttpSessionStateBase sessionStateBase, string validateCode)
        {
            sessionStateBase["ValidateCode"] = validateCode;
        }

        public string GetValidateCode(HttpSessionStateBase sessionStateBase)
        {
            return sessionStateBase["ValidateCode"].ToString();
        }
    }
}
