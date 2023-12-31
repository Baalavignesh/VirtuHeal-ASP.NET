﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtuHeal.Data;

#nullable disable

namespace VirtuHeal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230710172150_SingleChatTableUpdated")]
    partial class SingleChatTableUpdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VirtuHeal.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<string>("InitiatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PsychiatristId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("VirtuHeal.Models.College", b =>
                {
                    b.Property<int>("college_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("college_id"));

                    b.Property<string>("college_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_partner")
                        .HasColumnType("bit");

                    b.HasKey("college_id");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("VirtuHeal.Models.MyChats", b =>
                {
                    b.Property<int>("MyChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MyChatId"));

                    b.Property<int?>("PsychiatristId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("MyChatId");

                    b.HasIndex("PsychiatristId");

                    b.HasIndex("StudentId");

                    b.ToTable("MyChats");
                });

            modelBuilder.Entity("VirtuHeal.Models.Psychiatrist", b =>
                {
                    b.Property<int>("psychiatrist_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("psychiatrist_id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<int>("college_id")
                        .HasColumnType("int");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_verified")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resume_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("psychiatrist_id");

                    b.HasIndex("UserId")
                        .IsUnique();

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

                    b.HasIndex("psychiatrist_id");

                    b.ToTable("PsychiatristpQuestions");
                });

            modelBuilder.Entity("VirtuHeal.Models.SingleChatMessage", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentChatId")
                        .HasColumnType("int");

                    b.Property<string>("SenderRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId");

                    b.HasIndex("ParentChatId");

                    b.ToTable("SingleChatMessage");
                });

            modelBuilder.Entity("VirtuHeal.Models.Student", b =>
                {
                    b.Property<int>("student_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("student_id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<int>("college_id")
                        .HasColumnType("int");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("my_psychiatrist")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("student_id");

                    b.HasIndex("UserId")
                        .IsUnique();

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

                    b.HasIndex("student_id");

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

            modelBuilder.Entity("VirtuHeal.Models.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("VirtuHeal.Models.MyChats", b =>
                {
                    b.HasOne("VirtuHeal.Models.Psychiatrist", "Psychiatrist")
                        .WithMany("MyChats")
                        .HasForeignKey("PsychiatristId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VirtuHeal.Models.Student", "Student")
                        .WithMany("MyChats")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Psychiatrist");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("VirtuHeal.Models.Psychiatrist", b =>
                {
                    b.HasOne("VirtuHeal.Models.User", "User")
                        .WithOne("Psychiatrist")
                        .HasForeignKey("VirtuHeal.Models.Psychiatrist", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VirtuHeal.Models.PsychiatristpQuestions", b =>
                {
                    b.HasOne("VirtuHeal.Models.Psychiatrist", "Psychiatrist")
                        .WithMany()
                        .HasForeignKey("psychiatrist_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Psychiatrist");
                });

            modelBuilder.Entity("VirtuHeal.Models.SingleChatMessage", b =>
                {
                    b.HasOne("VirtuHeal.Models.MyChats", "MyChats")
                        .WithMany("SingleChatMessages")
                        .HasForeignKey("ParentChatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MyChats");
                });

            modelBuilder.Entity("VirtuHeal.Models.Student", b =>
                {
                    b.HasOne("VirtuHeal.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("VirtuHeal.Models.Student", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VirtuHeal.Models.StudentQuestions", b =>
                {
                    b.HasOne("VirtuHeal.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("student_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("VirtuHeal.Models.UserSession", b =>
                {
                    b.HasOne("VirtuHeal.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VirtuHeal.Models.MyChats", b =>
                {
                    b.Navigation("SingleChatMessages");
                });

            modelBuilder.Entity("VirtuHeal.Models.Psychiatrist", b =>
                {
                    b.Navigation("MyChats");
                });

            modelBuilder.Entity("VirtuHeal.Models.Student", b =>
                {
                    b.Navigation("MyChats");
                });

            modelBuilder.Entity("VirtuHeal.Models.User", b =>
                {
                    b.Navigation("Psychiatrist")
                        .IsRequired();

                    b.Navigation("Student")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
