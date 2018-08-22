using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGames.Models
{
    public class CommentCreate
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public string CommentText { get; set; }
    }
}