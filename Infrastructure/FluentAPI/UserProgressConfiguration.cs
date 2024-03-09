using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FluentAPI
{
    internal class UserProgressConfiguration : IEntityTypeConfiguration<UserProgress>
    {
        public void Configure(EntityTypeBuilder<UserProgress> builder)
        {
          builder.HasKey(x => new {x.CourseId,x.AccountId});
          builder.Ignore(x => x.Id);
        }
    }
}
