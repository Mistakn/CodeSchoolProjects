using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog {
    class Program {
        static void Main(string[] args) {
            using MyBlogContext contextDB = new();

            //var googleBlogPost = new Blog {
            //    URL = "http://google.com",
            //    Rating = 3,
            //    Posts = new List<Post> {
            //        new Post {
            //            Content = "My content",
            //            Title = "My Post"
            //        },
            //        new Post {
            //            Content = "My content 2",
            //            Title = "My Post 2"
            //        },
            //        new Post {
            //            Content = "My content 3",
            //            Title = "My Post 3"
            //        }
            //    }
            //};

            //contextDB.Blog.Add(googleBlogPost);


            //var yahooBlogPost = new Blog {
            //    URL = "http://yahoo.com",
            //    Rating = 3,
            //    Posts = new List<Post> {
            //        new Post {
            //            Content = "My Yahoo content",
            //            Title = "My Yahoo Post"
            //        },
            //        new Post {
            //            Content = "My Yahoo content 2",
            //            Title = "My Yahoo Post 2"
            //        },
            //        new Post {
            //            Content = "My Yahoo content 3",
            //            Title = "My Yahoo Post 3"
            //        }
            //    }
            //};

            //contextDB.Blog.Add(yahooBlogPost);


            //contextDB.SaveChanges();

            // Include = JOIN
            // ThenInclude = JOIN anidado
            // Este query de entitiy se traera todas las columnas de las tablas especificadas
            var categories = contextDB.Category.Include(category => category.Blogs).ThenInclude(blog => blog.Posts);

            Console.WriteLine(categories.ToQueryString());
            Console.WriteLine();

            foreach (var category in categories) {
                Console.WriteLine(category.Name);

                foreach (var blog in category.Blogs) {
                    Console.WriteLine($"\t{blog.URL}");

                    foreach (var post in blog.Posts) {
                        Console.WriteLine($"\t\t{post.Title}");
                    }
                }
            }


            var blogsWithPosts = contextDB.Blog
                .Select(
                blog => new {
                    blog.URL,
                    blog.Rating,
                    Category = blog.Category,
                    Posts = blog.Posts.Select(post => new {
                        post.PublishedDate,
                        post.Title
                    })
                }).OrderBy(blog => blog.Rating);

            Console.WriteLine(blogsWithPosts.ToQueryString());

            // Must convert IOrderedQueryable to IEnumerable to be able to group
            // Usually tels you to convert to list first
            var blogsGroupedByCategory = blogsWithPosts
                .ToList()
                .GroupBy(blog => blog.Category);


            foreach (var blog in blogsWithPosts) {
                Console.WriteLine(blog.URL);
                Console.WriteLine(blog.Rating);
                Console.WriteLine(blog.Category);
                foreach (var post in blog.Posts) {
                    Console.WriteLine($"\t{post.Title}\t{post.PublishedDate}");
                }
            }

        }
    }
}
