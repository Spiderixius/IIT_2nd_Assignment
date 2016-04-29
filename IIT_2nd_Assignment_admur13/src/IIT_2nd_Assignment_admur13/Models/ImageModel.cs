using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IIT_2nd_Assignment_admur13.Models
{
    public class ImageModel
    {
        // Auto incremented ID also put it as primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        // Image is saved into the database inside a byte array
        public byte[] ImageBytes { get; set; }

        public string ImageType { get; set; }

    }
}
