using BetterReviews.Controllers.Business.Services;
using BetterReviews.Controllers.Business.ViewModels;
using BetterReviews.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BetterReviews.Controllers.Business
{
    public class BusinessViewModelFactory
    {
        private readonly BusinessService _businessService = new BusinessService();
        private readonly BetterReviewsEntities _database = new BetterReviewsEntities();

        public AddBusinessViewModel CreateAddViewModel()
        {
            var model = new AddBusinessViewModel();
            model.BusinessCategories = _database.BusinessCategories.Select(x => new System.Web.Mvc.SelectListItem() { 
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            model.BusinessCategories.Insert(0, new System.Web.Mvc.SelectListItem() { 
                Value = "",
                Text = ""
            });

            return model;
        }

        public WriteReviewViewModel CreateWriteReviewViewModel(int businessId)
        {
            var model = new WriteReviewViewModel();

            model.BusinessId = businessId;
            model.RatingOptions = (new[] { 1, 2, 3, 4, 5 }).Select(x => new SelectListItem() {
                Value = x.ToString(),
                Text = $"Rating {x}"
            }).ToList();

            return model;
        }

        public BusinessViewModel CreateBusinessViewModel(int businessId)
        {
            var model = new BusinessViewModel();

            var business = _database.Businesses.Find(businessId);

            model.Name = business.Name;
            model.Description = "";
            model.Rating = 5;
            model.BusinessId = businessId;

            model.Reviews = CreateBusinessReviewsModel(businessId);

            return model;
        }

        private List<ReviewViewModel> CreateBusinessReviewsModel(int businessId)
        {
            var model = new List<ReviewViewModel>();

            var reviewResults = _businessService.GetReviewResults(businessId);

            foreach (var x in reviewResults)
            {
                var reviewModel = new ReviewViewModel();
                reviewModel.ReviewerName = $"{x.FirstName} {x.LastName}";
                reviewModel.UserName = x.UserName;
                reviewModel.ReviewText = x.Review;
                reviewModel.Rating = x.Rating;
                reviewModel.SubmittedDate = x.SubmittedDate.ToShortDateString();

                model.Add(reviewModel);
            }

            return model;
        }

        public List<BusinessViewModel> CreateBusinessListViewModel()
        {
            var ctx = new BetterReviewsEntities();

            var model = ctx.Businesses.Select(x => new BusinessViewModel()
            {
                Name = x.Name,
                BusinessId = x.Id
            }).ToList();

            return model;
        }
    }
}