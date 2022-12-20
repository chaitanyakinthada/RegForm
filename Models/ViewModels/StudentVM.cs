using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class StudentVM
    {
        public Student Student { get; set; }
        public Country Country { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }



        //public Course Course { get; set; }
        [Required]
        public List<Course> Courses { get; set; }
    }
}
