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
    internal class SongDetailConfiguration : IEntityTypeConfiguration<SongDetail>
    {
        public void Configure(EntityTypeBuilder<SongDetail> builder)
        {
            builder.HasOne(x=>x.Song).WithMany(song=>song.Detail).HasForeignKey(x=>x.SongId);
            builder.HasOne(x => x.Note).WithMany(note=>note.SongDetail).HasForeignKey(x => x.NoteId);
        }
    }
}
