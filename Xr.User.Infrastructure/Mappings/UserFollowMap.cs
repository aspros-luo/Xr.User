using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xr.User.Domain;


namespace Xr.User.Infrastructure
{
    public class UserFollowMap : ModelBuilderExtenions.EntityMappingConfiguration<UserFollow>
    {
        public override void Map(EntityTypeBuilder<UserFollow> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("user_follow");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.Type);
            entityTypeBuilder.Property(i => i.ValueId).HasColumnName("value_id");

            entityTypeBuilder.Property(i => i.Status);
            entityTypeBuilder.Property(i => i.Creator);
            entityTypeBuilder.Property(i => i.GmtCreated).HasColumnName("gmt_created");
            entityTypeBuilder.Property(i => i.Modifier);
            entityTypeBuilder.Property(i => i.GmtModified).HasColumnName("gmt_modified");
            entityTypeBuilder.Property(i => i.IsDeleted).HasColumnName("is_deleted");

            entityTypeBuilder.HasOne(i => i.User)
                .WithMany(i => i.UserFollows)
                .HasForeignKey(i => i.UserId);
        }
    }
}
