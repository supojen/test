using System;
using System.ComponentModel.DataAnnotations;

namespace Plantsist.Data
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public int Age { get; set; }    
        public string Name { get; set; }
    }
}