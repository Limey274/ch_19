using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 20 characters")]
        public string Name { get; set; }

        

       }
}
