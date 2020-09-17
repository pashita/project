using BetterReviews.Controllers.Business;
using BetterReviews.Controllers.Business.Services;
using BetterReviews.Controllers.Business.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace BetterReviews.Features.Business
{
    [Authorize]
    public class BusinessController : Controller
    {
        private readonly BusinessService _businessService;
        private readonly BusinessViewModelFactory _viewModelFactory;

        public BusinessController()
        {
            _businessService = new BusinessService();
            _viewModelFactory = new BusinessViewModelFactory();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var model = _viewModelFactory.CreateBusinessListViewModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = _viewModelFactory.CreateAddViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddBusinessViewModel model)
        {
            if (ModelState.IsValid)
            {
                _businessService.AddBusiness(model);
                return View("_ConfirmAddBusiness");
            }

            model.BusinessCategories = _viewModelFactory.CreateAddViewModel().BusinessCategories;
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var model = _viewModelFactory.CreateBusinessViewModel(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult WriteReview(int id)
        {
            var model = _viewModelFactory.CreateWriteReviewViewModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult WriteReview(WriteReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.User.Identity.GetUserId();
                _businessService.AddBusinessReview(model, userId);
                return RedirectToAction("detail", new { id = model.BusinessId });
            }

            model.RatingOptions = _viewModelFactory.CreateWriteReviewViewModel(model.BusinessId).RatingOptions;
            return View(model);
        }
    }
}