using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ChefsNDishes.CustomValidators;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int ChefId { get; set; }

        [Required(ErrorMessage = "is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [BirthDay]
        [Required(ErrorMessage = "is required")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
        }
    }
