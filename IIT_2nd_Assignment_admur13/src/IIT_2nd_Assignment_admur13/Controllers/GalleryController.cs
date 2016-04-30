using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IIT_2nd_Assignment_admur13.Models;
using IIT_2nd_Assignment_admur13.ViewModels.Gallery;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System.IO;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNet.Http;

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

        // GET: /Gallery/UploadImage
        [HttpGet]
        [Authorize]
        public IActionResult ShowUpload()
        {
            return View("UploadImage");
        }

        // POST: /Gallery/UploadImage
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult UploadImage(ImageUploadViewModel model)
        {
            if (ModelState.IsValid)
            {
                var img = model.Image;

                Byte[] imageBytes;
                using (Stream _stream = img.OpenReadStream())
                {
                    imageBytes = ReadFully(_stream, (int) _stream.Length);
                }

                ImageModel image = new ImageModel
                {
                    Title = model.Title,
                    ImageBytes = imageBytes,
                    ImageType = img.ContentType
                };
                using (_appDbContext)
                {
                    _appDbContext.Images.Add(image);
                    _appDbContext.SaveChanges();
                }
                return RedirectToAction("Gallery");
            }
            else {
                ModelState.AddModelError(string.Empty, "Error uploading image.");
                return View(model);
            }
        }
        
        // Pretty much resued my method of deleting in the UsersController.cs
        // POST: /Gallery/Delete
        [HttpPost, ActionName("DeleteImage")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteImage(int id)
        {
            try
            {
                ImageModel img = _appDbContext.Images.Single(x => x.Id == id);
                _appDbContext.Images.Remove(img);
                _appDbContext.SaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("Gallery");
        }


        /// <summary>
        ///  This section is for code copied from an external source. The copied code is appropriately marked with an URL above it. 
        ///  Comments are by the author of the code snippet.
        /// </summary>

        // Code copied from http://www.yoda.arachsys.com/csharp/readbinary.html and yes I understand what is going on!

        public static byte[] ReadFully(Stream stream, int initialLength)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }

    }

}
