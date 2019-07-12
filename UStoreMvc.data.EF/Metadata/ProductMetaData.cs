using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UStoreMvc.data.EF//.Metadata
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {

    }

    public class ProductMetaData
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Product Name")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string Name { get; set; }
        
        [StringLength(250, ErrorMessage = "Max 250 characters")]
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        [Required(ErrorMessage = "* Required")]
        public int UnitsInStock { get; set; }

        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Status ID")]
        public int StatusId { get; set; }
        
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }
        
        public string Notes { get; set; }
        
        [Display(Name = "Reference URL")]
        public string ReferenceURL { get; set; }

    }
}
