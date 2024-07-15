using Framework.web.Data;
using Framework.web.Models.Domain;
using Framework.web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Framework.web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;

        //private BloggieDbContext _bloggieDbContext;
        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
            //_bloggieDbContext = bloggieDbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //[ActionName("Add")]
        //public IActionResult SubmitTag()
        //{

        //    var name = Request.Form["name"];
        //    var displayName = Request.Form["displayName"];
        //    return View("Add");
        //}

        [HttpPost]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            bloggieDbContext.Tags.Add(tag);
            bloggieDbContext.SaveChanges();

            return View("Add");
        }
    }
}
