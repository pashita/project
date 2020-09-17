using BetterReviews.Database.Entities;
using BetterReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetterReviews.Controllers.Account.Services
{
    public class AccountService
    {
        public void SaveUserProfile(string userId, RegisterViewModel model)
        {
            var ctx = new BetterReviewsEntities();

            var profile = new UserProfile()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = userId
            };

            ctx.UserProfiles.Add(profile);
            ctx.SaveChanges();            
        }
    }
}