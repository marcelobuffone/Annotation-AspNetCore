using MBAM.Annotations.Domain.Annotations;
using MBAM.Annotations.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBAM.Annotations.Infra.Data.Mappings
{
    public class AnnotationMapping : EntityTypeConfiguration<Annotation>
    {
        public override void Map(EntityTypeBuilder<Annotation> builder)
        {
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Annotations");
        }
    }
}
