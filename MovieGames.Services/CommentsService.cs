using MoveGames.Data;
using MovieGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGames.Services
{
    public class CommentService
    {
        private readonly int _CommentId;
        private readonly Guid _userId;
        private readonly int _movieId;

        public CommentService() { }

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public CommentService(Guid userId, int movieId)
        {
            _userId = userId;
            _movieId = movieId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
               new Comment
               {
                   UserId = _userId,
                   MovieId = _movieId,
                   CommentText = model.CommentText,
                   CreatedDate = DateTimeOffset.UtcNow,
                   UserName = "TemporaryPlaceholderName" 
               };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public CommentDetail GetSingleCommentById(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comment =
                    ctx
                        .Comments
                        .SingleOrDefault(r => r.CommentId == commentId);

                return
                    new CommentDetail()
                    {
                        UserId = comment.UserId,
                        MovieId = comment.MovieId,
                        CommentText = comment.CommentText,
                        CommentId = comment.CommentId,
                        UserName = comment.UserName,
                        CreatedDate = comment.CreatedDate,
                        ModifiedDate = comment.CreatedDate
                    };
            }
        }

        public ICollection<CommentListItem> GetAllComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comments =
                    ctx
                        .Comments
                        .Where(r => r.UserId == _userId)
                        .Select(
                            e => new CommentListItem()
                            {
                                
                                UserId = e.UserId,
                                CommentText = e.CommentText,
                                CreatedDate = e.CreatedDate,
                                
                            });

                return comments.ToList();
            }
        }

        public ICollection<CommentListItem> GetAllCommentsByCommentId(int CommentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comments =
                    ctx
                        .Comments
                        .Where(c => c.MovieId == CommentId)
                        .Select(
                            e => new CommentListItem()
                            {
                                CommentId = e.CommentId,
                                UserId = e.UserId,
                                CommentText = e.CommentText,
                                CreatedDate = e.CreatedDate

                            });

                var CommentList = comments.ToList();

                foreach (var comment in CommentList)
                {
                    comment.UserName = GetNameFromUserId(comment.UserId);
                }

                return CommentList;
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            throw new NotImplementedException();
        }


        public bool DeleteComment(int lessonId)
        {
            throw new NotImplementedException();
        }

        private string GetNameFromUserId(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx
                        .Users
                        .SingleOrDefault(u => u.Id == userId.ToString());

                return user.UserName;
            }
        }
    }
}