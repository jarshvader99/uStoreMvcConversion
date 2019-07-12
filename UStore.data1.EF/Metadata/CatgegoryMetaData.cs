using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UStore.data1.EF;


namespace UStore.data1.EF//.Metadata
{
    [MetadataType(typeof(CatgegoryMetaData))]
        public partial class Category
        {

        }

    public class CatgegoryMetaData
    {
       

        public int CategoryID { get; set; }
        
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }


        public string Notes { get; set; }
    }
}
