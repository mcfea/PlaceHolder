using System;
using System.Linq;
using System.Web.Mvc;
using PlaceHolderProject.Repositories.Posts;

namespace PlaceHolderProject.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }

        public ActionResult Index()
        {
            var posts = _postRepository.GetAll().Take(10);
            
            return View(posts);
        }

        public ActionResult Detail(int postId)
        {
            var post = _postRepository.GetById(postId);

            return View(post);
        }
    }
}