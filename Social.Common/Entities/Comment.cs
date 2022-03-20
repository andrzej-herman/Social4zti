using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Common.Entities
{
    public class Comment
    {
        public string CommentId { get; set; }
        public string PostId { get; set; }
        public string CommentAuthorId { get; set; }
        public string CommentText { get; set; }
    }
}
