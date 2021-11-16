using IsGorevTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DAL.EntityFramework.Mapping
{
    public class JobWorkMap : IEntityTypeConfiguration<JobWork>
    {
        public void Configure(EntityTypeBuilder<JobWork> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnType("ntext");

            builder.HasOne(x => x.Urgency).WithMany(x => x.JobWork).HasForeignKey(x => x.UrgencyId);
        }
    }
}
