using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetterReviews.Controllers.Business.ViewModels
{
    public class ReviewViewModel
    {
        public string ReviewerName { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string SubmittedDate { get; set; }
        public string ReviewText { get; set; }
    }
}