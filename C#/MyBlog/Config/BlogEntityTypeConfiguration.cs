using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Config {
    public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog> {
        public void Configure(EntityTypeBuilder<Blog> builder) {
            builder.Property(b => b.URL)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .IsRequired();

            builder.Property(b => b.Rating)
                .HasDefaultValue(3);
        }
    }
}
