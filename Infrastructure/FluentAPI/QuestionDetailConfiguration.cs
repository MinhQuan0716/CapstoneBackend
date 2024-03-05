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
    internal class QuestionDetailConfiguration : IEntityTypeConfiguration<QuestionDetail>
    {
        public void Configure(EntityTypeBuilder<QuestionDetail> builder)
        {
            builder.HasKey(x => new { x.QuestionId, x.ChoiceId });
            builder.Ignore(x => x.Id);
        }
    }
}
