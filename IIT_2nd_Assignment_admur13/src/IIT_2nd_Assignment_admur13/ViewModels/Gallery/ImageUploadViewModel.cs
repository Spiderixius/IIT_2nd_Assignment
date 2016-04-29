using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IIT_2nd_Assignment_admur13.ViewModels.Gallery
{

    // For this particular implementation I simply used the existing classes from the Manage directory to understand this part
    public class ImageUploadViewModel
    {
        [Required]
        // Yes, I like long titles...
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]  
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        // Just a Prop. ah Java how come you don't have this :'(
        public string Title { get; set; } 

        // For the image
        [Required]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif,bnp,ico svg,PNG,JPG,JPEG,GIF,BNP,SVG,ICO")]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

    }
}
