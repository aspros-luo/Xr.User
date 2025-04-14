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
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd().HasColumnType("BIGINT(20)").HasColumnName("id");
            entityTypeBuilder.Property(i => i.Type).HasColumnType("TINYINT(4)").HasColumnName("type");
            entityTypeBuilder.Property(i => i.ValueId).HasColumnType("BIGINT(20)").HasColumnName("value_id");
            entityTypeBuilder.Property(i => i.UserId).HasColumnType("BIGINT(20)").HasColumnName("user_id");
            entityTypeBuilder.Property(i => i.FollowTime).HasColumnType("DATETIME").HasColumnName("follow_time");

            entityTypeBuilder.Property(i => i.Status).HasColumnType("TINYINT(4)").HasConversion<byte>().HasColumnName("status");
            entityTypeBuilder.Property(i => i.Creator).HasColumnType("BIGINT(20)").HasColumnName("creator");
            entityTypeBuilder.Property(i => i.GmtCreated).HasColumnType("DATETIME").HasColumnName("gmt_created");
            entityTypeBuilder.Property(i => i.Modifier).HasColumnType("BIGINT(20)").HasColumnName("modifier");
            entityTypeBuilder.Property(i => i.GmtModified).HasColumnType("DATETIME").HasColumnName("gmt_modified");
            entityTypeBuilder.Property(i => i.IsDeleted).HasColumnType("TINYINT").HasConversion<byte>().HasColumnName("is_deleted");

            entityTypeBuilder.HasOne(i => i.User)
                .WithMany(i => i.UserFollows)
                .HasForeignKey(i => i.UserId);
        }
    }
}
