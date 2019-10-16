using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dappertutorial.Models
{
    public class TodoItem
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
