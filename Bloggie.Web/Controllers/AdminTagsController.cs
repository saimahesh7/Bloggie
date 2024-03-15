using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext _dbContext;

        public AdminTagsController(BloggieDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            //Converting AddTagRequest data into Tag Domain Model 
            var tag = new Tag()
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };
            _dbContext.Tags.Add(tag);
            _dbContext.SaveChanges();

            return View("Add");
        }
    }
}
