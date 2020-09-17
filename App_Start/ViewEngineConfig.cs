using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BetterReviews
{ 
    /// <summary>
    ///  Overrides the default view engine for MVC actions. This is done because the views for this project
    ///  are put into their individual feature folders.
    /// </summary>
    public class ViewEngineConfig : RazorViewEngine
    {
        /// <summary>
        ///  Constructor for the custom view engine.
        /// </summary>
        public ViewEngineConfig() : base()
        {
            List<string> masterLocationFormats = MasterLocationFormats.ToList();
            List<string> partialViewLocationFormats = PartialViewLocationFormats.ToList();
            List<string> viewLocationFormats = ViewLocationFormats.ToList();

            List<string> featureLocationFormats = new List<string>
                {
                    "~/Features/{1}/Views/{0}.cshtml",
                    "~/Features/{1}/Views/Shared/{0}.cshtml",
                };

            masterLocationFormats.AddRange(featureLocationFormats);
            partialViewLocationFormats.AddRange(featureLocationFormats);
            viewLocationFormats.AddRange(featureLocationFormats);

            this.MasterLocationFormats = masterLocationFormats.ToArray();
            this.PartialViewLocationFormats = partialViewLocationFormats.ToArray();
            this.ViewLocationFormats = viewLocationFormats.ToArray();
        }
    }
}