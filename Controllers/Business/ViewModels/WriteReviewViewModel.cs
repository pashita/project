using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetterReviews.Controllers.Business.ViewModels
{
    public class WriteReviewViewModel
    {
        [Required]
        public int Rating { get; set; }

        public List<SelectListItem> RatingOptions { get; set; }

        [Required]
        public string Review { get; set; }

        public int BusinessId { get; set; }
    }
}