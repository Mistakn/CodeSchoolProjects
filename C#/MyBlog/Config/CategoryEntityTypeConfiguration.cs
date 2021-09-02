using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Config {
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.Property(c => c.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasMaxLength(10)
                .IsRequired();

            builder.HasData(
                new Category[] {
                    new Category {
                        CategoryID = 1,
                        Name = "Sports"
                    },
                    new Category {
                        CategoryID = 2,
                        Name = "Climate"
                    },
                    new Category {
                        CategoryID = 3,
                        Name = "Traffic"
                    },
                }
                );
        }
    }
}
