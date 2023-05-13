using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DUPL_RD.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Quentity { get; set; }
    }
}