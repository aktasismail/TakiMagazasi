//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ECommerceDataAccess.Data.Config
//{
//    public class RoleConfig : IEntityTypeConfiguration<IdentityRole>
//    {
//        public void Configure(EntityTypeBuilder<IdentityRole> entityType)
//        {
//            entityType.HasData(
//                    new IdentityRole
//                    {
//                        Name = "User",
//                        NormalizedName = "USER"
//                    },
//                    new IdentityRole
//                    {
//                        Name = "Admin",
//                        NormalizedName = "Admin"
//                    }
//                );
//        }
//    }
//}
