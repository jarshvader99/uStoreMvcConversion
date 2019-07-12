using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UStore.data1.EF//.Metadata
{
    [MetadataType(typeof(StatusMetaData))]
    public partial class Status
    {

    }

    public class StatusMetaData
    {
        public int StatusID { get; set; }
        [Display(Name = "Status Name")]
        public string StatusName { get; set; }
        [Display(Name = "Status Order")]
        public byte StatusOrder { get; set; }
        public string Notes { get; set; }
    }
}
