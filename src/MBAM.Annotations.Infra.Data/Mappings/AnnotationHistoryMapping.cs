using MBAM.Annotations.Domain.Annotations;
using MBAM.Annotations.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBAM.Annotations.Infra.Data.Mappings
{
    public class AnnotationHistoryMapping : EntityTypeConfiguration<AnnotationHistory>
    {
        public override void Map(EntityTypeBuilder<AnnotationHistory> builder)
        {
            builder.Property(e => e.Description)
                .HasColumnType("varchar(650)")
                .HasColumnName("description")
                .IsRequired();

            builder.Property(e => e.Title)
                .HasColumnType("varchar(100)")
                .HasColumnName("title")
                .IsRequired();

            builder.Property(e => e.CreateDate)
                .HasColumnName("create_date")
                .IsRequired();


            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);

            builder.HasOne(e => e.Annotation)
                .WithMany(o => o.AnnotationHistory)
                .HasForeignKey(e => e.AnnotationId);

            builder.ToTable("AnnotationHistories");
        }
    }
}
