using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetterReviews.Controllers.Business.Models
{
    public class ReviewResult
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Rating { get; set; }
        public string Review { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
}