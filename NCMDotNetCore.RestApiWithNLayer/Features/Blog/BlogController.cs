using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCMDotNetCore.RestApiWithNLayer.Db;

namespace NCMDotNetCore.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _bl_Blogs;

        public BlogController()
        {
            _bl_Blogs = new BL_Blog();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var lst = _bl_Blogs.GetBlogs();
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _bl_Blogs.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            var result = _bl_Blogs.CreateBlog(blog);

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _bl_Blogs.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
           
            var result = _bl_Blogs.UpdateBlog(id, blog);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _bl_Blogs.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            if (!string.IsNullOrEmpty(item.BlogTitle) || !string.IsNullOrEmpty(item.BlogAuthor) || !string.IsNullOrEmpty(item.BlogContent))
            {
                var result = _bl_Blogs.UpdateBlog(id, blog);
                string message = result > 0 ? "Updating Successful" : "Updating Failed";
                return Ok(message);
            }else
            {
                string message ="Updating Failed";
                return Ok(message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _bl_Blogs.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            
            var result = _bl_Blogs.DeleteBlog(id);
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    }
}
