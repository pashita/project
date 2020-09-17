using BetterReviews.Controllers.Business.Models;
using BetterReviews.Controllers.Business.ViewModels;
using BetterReviews.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterReviews.Controllers.Business.Services
{
    public class BusinessService
    {
        private readonly BetterReviewsEntities _database = new BetterReviewsEntities();

        public void AddBusiness(AddBusinessViewModel model)
        {
            var business = new BetterReviews.Database.Entities.Business();
            business.Name = model.BusinessName;
            business.EmailAddress = model.EmailAddress;
            business.WebsiteAddress = model.WebsiteAddress;
            business.PhoneNumber = model.PhoneNumber;

            business.Address = new Address();
            business.Address.Address1 = model.Address;
            business.Address.City = model.City;
            business.Address.ZipCode = model.ZipCode;
            business.Address.Country = model.Country;
            business.Address.State = model.State;

            business.BusinessCategoryId = model.BusinessCategoryId.Value;

            _database.Businesses.Add(business);
            _database.SaveChanges();
        }
        
        public void AddBusinessReview(WriteReviewViewModel model, string userId)
        {
            var review = new BusinessReview();

            review.Rating = model.Rating;
            review.Review = model.Review;
            review.SubmittedDate = DateTime.UtcNow;
            review.BusinessId = model.BusinessId;
            review.UserId = userId;

            _database.BusinessReviews.Add(review);
            _database.SaveChanges();
        }

        public List<ReviewResult> GetReviewResults(int businessId)
        {
            var ctx = _database;

            var q = (
                from br in ctx.BusinessReviews
                join u in ctx.AspNetUsers
                    on br.UserId equals u.Id
                join up in ctx.UserProfiles
                    on u.Id equals up.UserId into u_up
                from up in u_up.DefaultIfEmpty()
                where br.BusinessId == businessId
                orderby br.SubmittedDate descending
                select new ReviewResult
                {
                    UserName = u.UserName,
                    FirstName = up.FirstName,
                    LastName = up.LastName,
                    Review = br.Review,
                    Rating = br.Rating,
                    SubmittedDate = br.SubmittedDate
                });

            var results = q.ToList();

            return results;
        }
    }
}