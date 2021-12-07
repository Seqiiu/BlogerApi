using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postservice;
        public PostController(IPostService postService)
        {
            _postservice = postService;
        }
        [SwaggerOperation(Summary ="Pokaż wszystkie posty")]
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postservice.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postservice.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}
