﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADO.NET_.NET_CORE.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name ="Full Name:")]
        [Required(ErrorMessage ="Full Name is required.")]
        public string FullName { get; set; }
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Display(Name = "Mobile:")]
        public string Mobile { get; set; }
        [Display(Name = "Date Of Birth:")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Notes:")]
        //for generating automatically textarea
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }


    }
}
