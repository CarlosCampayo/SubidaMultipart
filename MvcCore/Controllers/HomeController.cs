using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCore.Helper;

namespace MvcCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [DisableRequestSizeLimit]
        //[RequestSizeLimit(52428800)]
        public async Task<IActionResult> Index(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                await SubidaMultiple.UploadFileAsync(memoryStream, file.FileName);
            }
            //SubidaMultiple.Main(file);
            ViewBag.Mensaje = "Proceso termiando";
            return View();
        }
    }
}
