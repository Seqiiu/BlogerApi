using Application.Dto;
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
        [SwaggerOperation(Summary ="Create a new post")]
        [HttpPost]
        public IActionResult Create(CreatePostDto newPost)
        {
            var post = _postservice.AddNewPost(newPost);
            return Created($"api/posts/{post.Id}", post);
        }
        [SwaggerOperation(Summary ="Update a existing post")]
        [HttpPut]
        public IActionResult Update( UpdatePostDto updatePost)
        {
            _postservice.UpdatePost(updatePost);
            return NoContent();
        }
        [SwaggerOperation(Summary ="Delete a specific post")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postservice.DeletePost(id);
            return NoContent();
        }
    }
}
