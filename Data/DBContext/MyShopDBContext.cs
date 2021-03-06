﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.DBContext
{
    // Context của tôi kế thừa từ thằng ApplicationUser để sau này sẽ tự động create các bảng liên quan đến user
    public class MyShopDBContext : IdentityDbContext<ApplicationUser>
    {
        public MyShopDBContext() : base("MyShop")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<UserCountry> UserCountry { get; set; }
        public DbSet<Users> UsersUndefined { get; set; }
        //  public DbSet<ApplicationUser> ApplicationIdentity  { get; set;}
        public static MyShopDBContext Create()
        {
            return new MyShopDBContext();
        }
        // 1 cú tạo các bảng như userrole, userlogin,role, userclaim
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
           // modelBuilder.Entity<Post>()
           //.HasOne(p => p.Blog)
           //.WithMany(b => b.Posts)
           //.HasForeignKey(p => p.BlogId)
           //.HasConstraintName("ForeignKey_Post_Blog");

        }
    }
  
}