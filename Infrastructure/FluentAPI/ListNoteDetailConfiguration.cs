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
    internal class ListNoteDetailConfiguration : IEntityTypeConfiguration<ListNoteDetail>
    {
        public void Configure(EntityTypeBuilder<ListNoteDetail> builder)
        {
            builder.HasKey(x => new { x.ListNoteId,x.NoteId});
            builder.HasOne(x=>x.ListNote).WithMany(song=>song.Detail).HasForeignKey(x=>x.ListNoteId);
            builder.HasOne(x => x.Note).WithMany(note=>note.ListNoteDetail).HasForeignKey(x => x.NoteId);
            builder.Ignore(x => x.Id);
        }
    }
}
