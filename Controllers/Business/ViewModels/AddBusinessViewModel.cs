using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetterReviews.Controllers.Business.ViewModels
{
    public class AddBusinessViewModel
    {
        [Required, Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Required, Display(Name = "Business Category")]
        public int? BusinessCategoryId { get; set; }

        public List<SelectListItem> BusinessCategories { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required, Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Website Address")]
        public string WebsiteAddress { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}