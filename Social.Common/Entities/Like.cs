using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Common.Entities
{
    public class Like
    {
        public string LikeId { get; set; }
        public string PostId { get; set; }
        public string LikeAuthorId { get; set; }
    }
}
