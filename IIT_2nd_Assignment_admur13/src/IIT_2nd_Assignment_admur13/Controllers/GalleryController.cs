using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IIT_2nd_Assignment_admur13.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IIT_2nd_Assignment_admur13.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;

        public GalleryController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: /Gallery/Gallery
        [HttpGet]
        [Authorize]
        public IActionResult Gallery()
        {
            List<ImageModel> imgModels = _appDbContext.Images.ToList();
            return View(imgModels);

        }

        [HttpGet]
        [Authorize]
        public IActionResult ShowUpload()
        {
            return View("UploadImage");
        }


    }
}
