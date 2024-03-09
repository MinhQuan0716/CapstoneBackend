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
    internal class UserQuizAttemptConfiguration : IEntityTypeConfiguration<UserQuizAttempt>
    {
        public void Configure(EntityTypeBuilder<UserQuizAttempt> builder)
        {
            builder.HasKey(t => new { t.QuizId, t.AccountId });
            builder.Ignore(x => x.Id);
        }
    }
}
