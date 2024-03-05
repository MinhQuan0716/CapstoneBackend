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
    internal class QuizDetailConfiguration : IEntityTypeConfiguration<QuizDetail>
    {
        public void Configure(EntityTypeBuilder<QuizDetail> builder)
        {
           builder.HasKey(x => new {x.QuestionId,x.QuizId});
            builder.Ignore(x => x.Id);
        }
    }
}
