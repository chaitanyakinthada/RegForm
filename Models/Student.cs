using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(15,50,ErrorMessage ="Age must be in between 15 and 50!")]
        public int Age { get; set; }
        [Required]
        //[RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string  Email { get; set; }
        [Required]
        public string Gender { get; set; }
        //[FileSize]
        public string ProfilePic { get; set; }
        
        public string Coursess { get; set; }

        //[Required]
        //[Display(Name="CourseId")]
        //public int CourseId { get; set; }
        //[ForeignKey("CourseId")]
        //public virtual Course Course { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Display(Name="CountryId")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
    //public class CountryList 
    //{
    //    public IList<Country> Countries { get; set; }
    //}

}
