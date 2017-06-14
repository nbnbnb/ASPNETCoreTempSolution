using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Reflection;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Logging;

namespace BasicSite.Controllers
{
    public class DemoController : Controller
    {
        private readonly IHtmlLocalizer<DemoController> _localizer;
        private readonly ILogger _logger;
        public DemoController(IHtmlLocalizer<DemoController> localizer,
            ILogger<DemoController> logger)
        {
            _localizer = localizer;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Globalization and localization
        /// </summary>
        /// <returns></returns>
        public IActionResult I18N()
        {
            ViewData["Greet"] = _localizer["Greet"];
            return View();
        }
    }

}