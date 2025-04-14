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
            entityTypeBuilder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd().HasMaxLength(20).HasColumnType("bigint(20)").HasColumnName("id");
            entityTypeBuilder.Property(i => i.HasAudit).HasColumnType("tinyint(4)").HasColumnName("has_audit");
            entityTypeBuilder.Property(i => i.RatePoint).HasColumnType("float(11,2)").HasColumnName("rate_point");

            entityTypeBuilder.Property(i => i.Status).HasColumnType("tinyint(4)").HasColumnName("status");
            entityTypeBuilder.Property(i => i.Creator).HasMaxLength(20).HasColumnType("bigint(20)").HasColumnName("creator");
            entityTypeBuilder.Property(i => i.GmtCreated).HasColumnType("datetime").HasColumnName("gmt_created");
            entityTypeBuilder.Property(i => i.Modifier).HasMaxLength(20).HasColumnType("bigint(20)").HasColumnName("modifier");
            entityTypeBuilder.Property(i => i.GmtModified).HasColumnType("datetime").HasColumnName("gmt_modified");
            entityTypeBuilder.Property(i => i.IsDeleted).HasColumnType("tinyint(4)").HasColumnName("is_deleted");

            entityTypeBuilder.HasOne(i => i.User)
                .WithOne(i => i.UserServer)
                .HasForeignKey<UserServer>(i => i.UserId);
        }
    }
}
