using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecordStore.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Genre { get; set; }
        
        [Required(ErrorMessage="An Album Must Have An Artist!!!")]
        public string Artist { get; set; }

        public string Title { get; set; }


    }
}