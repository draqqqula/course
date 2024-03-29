﻿// <auto-generated />
using System;
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dal.Migrations
{
    [DbContext(typeof(QuestionDbContext))]
    [Migration("20240329100559_update13")]
    partial class update13
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dal.Answers.Models.AnswerDal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Dal.Authors.Models.AuthorDal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Dal.Edits.Models.EditDal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Edits");
                });

            modelBuilder.Entity("Dal.Questions.Models.QuestionDal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("SolutionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Dal.Tags.Models.TagDal", b =>
                {
                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Text");

                    b.HasIndex("Text");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("QuestionDalTagDal", b =>
                {
                    b.Property<Guid>("QuestionsId")
                        .HasColumnType("uuid");

                    b.Property<string>("TagsText")
                        .HasColumnType("text");

                    b.HasKey("QuestionsId", "TagsText");

                    b.HasIndex("TagsText");

                    b.ToTable("QuestionDalTagDal");
                });

            modelBuilder.Entity("Dal.Answers.Models.AnswerDal", b =>
                {
                    b.HasOne("Dal.Authors.Models.AuthorDal", "Author")
                        .WithMany("Answers")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Questions.Models.QuestionDal", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Dal.Edits.Models.EditDal", b =>
                {
                    b.HasOne("Dal.Questions.Models.QuestionDal", "Question")
                        .WithMany("Edits")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Dal.Questions.Models.QuestionDal", b =>
                {
                    b.HasOne("Dal.Authors.Models.AuthorDal", "Author")
                        .WithMany("Questions")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("QuestionDalTagDal", b =>
                {
                    b.HasOne("Dal.Questions.Models.QuestionDal", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Tags.Models.TagDal", null)
                        .WithMany()
                        .HasForeignKey("TagsText")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dal.Authors.Models.AuthorDal", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Dal.Questions.Models.QuestionDal", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Edits");
                });
#pragma warning restore 612, 618
        }
    }
}
