using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xr.User.Domain;


namespace Xr.User.Infrastructure
{
    public class UserMap : ModelBuilderExtenions.EntityMappingConfiguration<Domain.User>
    {
        public override void Map(EntityTypeBuilder<Domain.User> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("user");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.UserName).HasColumnName("user_name");

            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.GmtCreated).HasColumnName("gmt_created");
            entityTypeBuilder.Property(i => i.Modifier);
            entityTypeBuilder.Property(i => i.GmtModified).HasColumnName("gmt_modified");
            entityTypeBuilder.Property(i => i.IsDeleted).HasColumnName("is_deleted");


        }
    }
}
