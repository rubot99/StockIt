using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockIt.Mvc.Services;
using System.Collections.Generic;

namespace StockIt.Mvc.Controllers
{
    public class BaseController : Controller
    {        
        public string Tenant = "rrhome";
    }
}
