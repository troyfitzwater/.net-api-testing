using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Quote
    {
        public Guid Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
