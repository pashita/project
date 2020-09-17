using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetterReviews.Controllers.Business.ViewModels
{
    public class BusinessViewModel
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }
}