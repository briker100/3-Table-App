using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveGames.Data
{
     public class Comment
    {
        [Display(Name = "Note was Created")]
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Comments { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
