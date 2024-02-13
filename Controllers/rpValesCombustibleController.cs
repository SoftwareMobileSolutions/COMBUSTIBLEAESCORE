using COMBUSTIBLEAESCORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using COMBUSTIBLEAESCORE.Interfaces;


namespace COMBUSTIBLEAESCORE.Controllers
{
    public class rpValesCombustibleController : Controller
    {
        IrpVales IrpVales;
        public rpValesCombustibleController(IrpVales _IrpVales)
        {
            IrpVales = _IrpVales;
        }
        public async Task<IActionResult> rpValesCombustible()
        {
            return await Task.Run(() => {
                return PartialView();
            });
        }

        [HttpGet]
        public async Task<JsonResult> getDataValesCombustible(string fini, string ffin)
        {
            int userid = 2982, 
                companyid = 6;
            var data = await IrpVales.getRpValesCombustible(userid, companyid, fini, ffin);
            return Json(data);
        } 
    }
}
