using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using org.huage.AuthManagement.DataBase.Table;

namespace org.huage.AuthManagement.DataBase.Mapping;

public class OrganizationMapping: IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.Property(_ => _.OrgCode).IsRequired();
        builder.HasIndex(_ => _.OrgCode).IsUnique();
        builder.Property(_ => _.Name).HasMaxLength(50);
    }
}