using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xr.User.Domain;


namespace Xr.User.Infrastructure
{
    public class UserServerMap : ModelBuilderExtenions.EntityMappingConfiguration<UserServer>
    {
        public override void Map(EntityTypeBuilder<UserServer> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("user_server");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.HasAudit).HasColumnName("has_audit");
            entityTypeBuilder.Property(i => i.RatePoint).HasColumnName("rate_point");

            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.GmtCreated).HasColumnName("gmt_created");
            entityTypeBuilder.Property(i => i.Modifier);
            entityTypeBuilder.Property(i => i.GmtModified).HasColumnName("gmt_modified");
            entityTypeBuilder.Property(i => i.IsDeleted).HasColumnName("is_deleted");

            entityTypeBuilder.HasOne(i => i.User)
                .WithOne(i => i.UserServer)
                .HasForeignKey<UserServer>(i => i.UserId);
        }
    }
}
