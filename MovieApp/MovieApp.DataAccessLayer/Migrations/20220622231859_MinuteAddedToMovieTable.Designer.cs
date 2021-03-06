// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.DataAccessLayer.Contexts;

#nullable disable

namespace MovieApp.Data.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20220622231859_MinuteAddedToMovieTable")]
    partial class MinuteAddedToMovieTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CategoryMovie", b =>
                {
                    b.Property<int>("CategoriesCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieID")
                        .HasColumnType("int");

                    b.HasKey("CategoriesCategoryID", "MoviesMovieID");

                    b.HasIndex("MoviesMovieID");

                    b.ToTable("CategoryMovie");
                });

            modelBuilder.Entity("MovieApp.EntityLayer.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MovieApp.EntityLayer.Entities.Director", b =>
                {
                    b.Property<int>("DirectorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DirectorID");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("MovieApp.EntityLayer.Entities.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DirectorID")
                        .HasColumnType("int");

                    b.Property<string>("ImageLgUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSmUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Minute")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MovieID");

                    b.HasIndex("DirectorID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieApp.EntityLayer.Entities.Star", b =>
                {
                    b.Property<int>("StarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StarID");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("MovieStar", b =>
                {
                    b.Property<int>("MoviesMovieID")
                        .HasColumnType("int");

                    b.Property<int>("StarsStarID")
                        .HasColumnType("int");

                    b.HasKey("MoviesMovieID", "StarsStarID");

                    b.HasIndex("StarsStarID");

                    b.ToTable("MovieStar");
                });

            modelBuilder.Entity("CategoryMovie", b =>
                {
                    b.HasOne("MovieApp.EntityLayer.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.EntityLayer.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieApp.EntityLayer.Entities.Movie", b =>
                {
                    b.HasOne("MovieApp.EntityLayer.Entities.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("MovieStar", b =>
                {
                    b.HasOne("MovieApp.EntityLayer.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.EntityLayer.Entities.Star", null)
                        .WithMany()
                        .HasForeignKey("StarsStarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
