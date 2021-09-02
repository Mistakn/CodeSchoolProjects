using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities {
    public class Post {

        public int? PostID { get; set; }

        public DateTime PublishedDate { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public int? BlogID { get; set; }

        public Blog Blog { get; set; }

    }
}
