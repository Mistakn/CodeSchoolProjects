using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities {
    public class Blog {

        [Key]
        public int BlogID { get; set; }

        public string? URL { get; set; }

        public int? Rating { get; set; }

        public int? CategoryID { get; set; }

        public Category Category { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}
