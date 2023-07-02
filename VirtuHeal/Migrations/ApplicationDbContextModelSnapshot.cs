﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtuHeal.Data;

#nullable disable

namespace VirtuHeal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VirtuHeal.Models.Psychiatrist", b =>
                {
                    b.Property<int>("psychiatrist_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("psychiatrist_id"));

                    b.Property<int>("college_id")
                        .HasColumnType("int");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<string>("qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("psychiatrist_id");

                    b.ToTable("Psychiatrists");
                });

            modelBuilder.Entity("VirtuHeal.Models.PsychiatristpQuestions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("psychiatrist_id")
                        .HasColumnType("int");

                    b.Property<string>("question1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PsychiatristpQuestions");
                });

            modelBuilder.Entity("VirtuHeal.Models.Student", b =>
                {
                    b.Property<int>("student_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("student_id"));

                    b.Property<int>("college_id")
                        .HasColumnType("int");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("my_psychiatrist")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<string>("qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("student_id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("VirtuHeal.Models.StudentQuestions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("student_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("StudentQuestions");
                });

            modelBuilder.Entity("VirtuHeal.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"));

                    b.Property<bool>("is_online")
                        .HasColumnType("bit");

                    b.Property<byte[]>("password_hash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("password_salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
