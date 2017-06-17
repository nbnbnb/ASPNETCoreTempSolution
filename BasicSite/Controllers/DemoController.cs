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
using Microsoft.Extensions.FileProviders;

namespace BasicSite.Controllers
{
    public class DemoController : Controller
    {
        private readonly IHtmlLocalizer<DemoController> _localizer;
        private readonly ILogger _logger;
        private readonly IFileProvider _fileProvider;

        public DemoController(
            IHtmlLocalizer<DemoController> localizer,
            ILogger<DemoController> logger,
            IFileProvider fileProvider)
        {
            _localizer = localizer;
            _logger = logger;
            _fileProvider = fileProvider;
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

        public IActionResult FileProvider()
        {
            var contents = _fileProvider.GetDirectoryContents(""); // 应用程序的根目录
            return View(contents);
        }

        public IActionResult MyTempData()
        {
            TempData["a"] = "aaa";
            TempData["now"] = DateTime.Now.ToString();
            return View();
        }

        public ActionResult ToAnother()
        {
            return View();
        }
    }

}