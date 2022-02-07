using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlaceHolderProject.Repositories.Comments;

namespace PlaceHolderProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CommentsForPost(int postId)
        {
            var commments = _commentRepository.GetCommentsByPostId(postId);
            return PartialView(commments);
        }

    }
}