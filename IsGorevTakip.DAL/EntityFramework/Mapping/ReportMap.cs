using IsGorevTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DAL.EntityFramework.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Definition).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Detail).HasColumnType("ntext");

            builder.HasOne(x => x.JobWork).WithMany(x => x.Report).HasForeignKey(x => x.JobWorkId);
        }
    }
}
