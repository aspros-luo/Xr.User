using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Xr.User.Infrastructure
{
    public class UserMap : ModelBuilderExtenions.EntityMappingConfiguration<Domain.User>
    {
        public override void Map(EntityTypeBuilder<Domain.User> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("user");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).IsRequired().HasMaxLength(20).HasColumnType("bigint(20)").ValueGeneratedOnAdd().HasColumnName("id");
            entityTypeBuilder.Property(i => i.UserName).IsRequired().HasMaxLength(20).HasColumnType("varchar(20)").HasColumnName("user_name");
            entityTypeBuilder.Property(i => i.Password).HasColumnType("varchar(100)").HasColumnName("password");
            entityTypeBuilder.Property(i => i.PasswordSalt).HasColumnType("varchar(100)").HasColumnName("password_salt");
            entityTypeBuilder.Property(i => i.Type).IsRequired().HasColumnType("tinyint(4)").HasColumnName("type");
            entityTypeBuilder.Property(i => i.NickName).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("nick_name");
            entityTypeBuilder.Property(i => i.RealName).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("real_name");
            entityTypeBuilder.Property(i => i.IdNo).HasMaxLength(20).HasColumnType("varchar(20)").HasColumnName("id_no");
            entityTypeBuilder.Property(i => i.IsReal).HasColumnType("tinyint(4)").HasColumnName("is_real");
            entityTypeBuilder.Property(i => i.Sex).HasColumnType("tinyint(4)").HasColumnName("sex");
            entityTypeBuilder.Property(i => i.Birthday).HasColumnType("datetime").HasColumnName("birthday");
            entityTypeBuilder.Property(i => i.Avatar).HasMaxLength(150).HasColumnType("varchar(150)").HasColumnName("avatar");
            entityTypeBuilder.Property(i => i.Phone).HasMaxLength(20).HasColumnType("varchar(150)").HasColumnName("phone");

            entityTypeBuilder.Property(i => i.Status).HasColumnType("tinyint(4)").HasColumnName("status");
            entityTypeBuilder.Property(i => i.Creator).HasMaxLength(20).HasColumnType("bigint(20)").HasColumnName("creator");
            entityTypeBuilder.Property(i => i.GmtCreated).HasColumnType("datetime").HasColumnName("gmt_created");
            entityTypeBuilder.Property(i => i.Modifier).HasMaxLength(20).HasColumnType("bigint(20)").HasColumnName("modifier");
            entityTypeBuilder.Property(i => i.GmtModified).HasColumnType("datetime").HasColumnName("gmt_modified");
            entityTypeBuilder.Property(i => i.IsDeleted).HasColumnType("tinyint(4)").HasColumnName("is_deleted");
        }
    }
}
