using IsGorevTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsGorevTakip.DAL.EntityFramework.Mapping
{
    public class DeclaretionMap : IEntityTypeConfiguration<Declarationn>
    {
        public void Configure(EntityTypeBuilder<Declarationn> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(x => x.Declarations).HasForeignKey(x => x.AppUserId);
        }
    }
}
