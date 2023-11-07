using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Comment
    {
        public int Id { get; set; }
    
        [Required]
        public string Author { get; set; }
    
        [Required]
        [MaxLength(30)]
        public string Text { get; set; }
    
        public DateTime Date { get; set; }
    }
}