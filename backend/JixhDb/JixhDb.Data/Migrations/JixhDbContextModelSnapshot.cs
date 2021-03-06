﻿// <auto-generated />
using JixhDb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JixhDb.Data.Migrations
{
    [DbContext(typeof(JixhDbContext))]
    partial class JixhDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JixhDb.Models.EntityModels.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("MovieId");

                    b.Property<int>("Rating");

                    b.Property<string>("Text")
                        .HasMaxLength(1000);

                    b.Property<string>("Title")
                        .HasMaxLength(35);

                    b.Property<string>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.Movie", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cast");

                    b.Property<string>("CoverUrl")
                        .IsRequired();

                    b.Property<string>("Director")
                        .IsRequired();

                    b.Property<double>("Duration");

                    b.Property<double>("Rating");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("StoryLine");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("TrailerLink")
                        .IsRequired();

                    b.Property<string>("Writers");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.MovieCategory", b =>
                {
                    b.Property<string>("CategoryId");

                    b.Property<string>("MovieId");

                    b.HasKey("CategoryId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCategory");
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.MovieRaiting", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Movieid");

                    b.Property<double>("Rate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Movieid");

                    b.HasIndex("UserId");

                    b.ToTable("MovieRatings");
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.Review", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("MovieId");

                    b.Property<int>("Rating");

                    b.Property<string>("Text")
                        .HasMaxLength(1000);

                    b.Property<string>("Title")
                        .HasMaxLength(35);

                    b.Property<string>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FieldForChange");

                    b.Property<int>("Gender");

                    b.Property<string>("HomeTown");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<bool>("MarkedForChange");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePicUrl");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.Comment", b =>
                {
                    b.HasOne("JixhDb.Models.EntityModels.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId");

                    b.HasOne("JixhDb.Models.EntityModels.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.HasOne("JixhDb.Models.EntityModels.User")
                        .WithMany("CommentsRated")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.MovieCategory", b =>
                {
                    b.HasOne("JixhDb.Models.EntityModels.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JixhDb.Models.EntityModels.Movie", "Movie")
                        .WithMany("Categories")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.MovieRaiting", b =>
                {
                    b.HasOne("JixhDb.Models.EntityModels.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("Movieid");

                    b.HasOne("JixhDb.Models.EntityModels.User", "User")
                        .WithMany("MoviesRated")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JixhDb.Models.EntityModels.Review", b =>
                {
                    b.HasOne("JixhDb.Models.EntityModels.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId");

                    b.HasOne("JixhDb.Models.EntityModels.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");

                    b.HasOne("JixhDb.Models.EntityModels.User")
                        .WithMany("ReviewsRated")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JixhDb.Models.EntityModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JixhDb.Models.EntityModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JixhDb.Models.EntityModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JixhDb.Models.EntityModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
