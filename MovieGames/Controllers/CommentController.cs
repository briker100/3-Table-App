using Microsoft.AspNet.Identity;
using MovieGames.Models;
using MovieGames.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieGames.Controllers
{
    public class CommentController : Controller
    {

        public ActionResult Index(string sortOrder)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            var model = service.GetAllComments();
            return View(model);
        }

        [Authorize]
        public ActionResult Create(int id)
        {
            var model = new CommentCreate
            {
                MovieId = id,
                UserId = Guid.Parse(User.Identity.GetUserId())
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId, comment.MovieId);

            if (service.CreateComment(comment))
            {
                TempData["SaveResult"] = "Your comment was created.";
                return RedirectToAction("Details", "Lesson", new { id = comment.MovieId });
            }

            ModelState.AddModelError("", "Comment could not be created");
            return View(comment);
        }

    }
}