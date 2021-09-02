using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Config {
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post> {
        public void Configure(EntityTypeBuilder<Post> builder) {

            // Build table with another name
            // builder.ToTable("CustomName");

            builder.Property(p => p.Content)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .IsRequired();

            builder.Property(p => p.Title)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .IsRequired();

            builder.Property(p => p.PublishedDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
