using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp1_1.Models
{
    [Table("Tbl_Blod")]
    public class BlodModel
    {
        [Key]
        //[Column("BlodId")]
        public int BoldId { get; set; }

        public string BoldTitle { get; set; }

        public string BlodAuthor { get; set; }

        public string BlodContent { get; set; }



    }
}
