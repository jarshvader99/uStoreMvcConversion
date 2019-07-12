using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UStore.Domain
{
    public class ProductModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Max 1000 characters")]
        public string Description { get; set; }


        public decimal Price { get; set; }

        [Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }

        [StringLength(75, ErrorMessage = "Max 75 characters")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "* Required")]
        public int StatusId { get; set; }

        public int CategoryID { get; set; }

        [StringLength(500, ErrorMessage = "Max 500 characters")]
        public string Notes { get; set; }

        [StringLength(1024, ErrorMessage = "Max 1024 characters")]
        public string ReferenceURL { get; set; }


    }
}
