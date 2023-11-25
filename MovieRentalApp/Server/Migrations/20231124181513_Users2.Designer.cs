﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieRentalApp.Server.Data;

#nullable disable

namespace MovieRentalApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231124181513_Users2")]
    partial class Users2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MovieRentalApp.Shared.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Comedy",
                            Url = "comedy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Thriller",
                            Url = "thriller"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Action",
                            Url = "action"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rom Com",
                            Url = "rom-com"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sci-Fi",
                            Url = "sci-fi"
                        });
                });

            modelBuilder.Entity("MovieRentalApp.Shared.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Featured")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Neo (Keanu Reeves) believes that Morpheus (Laurence Fishburne), an elusive figure considered to be the most dangerous man alive, can answer his question -- What is the Matrix? Neo is contacted by Trinity (Carrie-Anne Moss), a beautiful stranger who leads him into an underworld where he meets Morpheus. They fight a brutal battle for their lives against a cadre of viciously intelligent secret agents. It is a truth that could cost Neo something more precious than his life.",
                            Featured = true,
                            GenreId = 5,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/ba/Poster_-_The_Matrix_Reloaded.jpg",
                            Title = "The Matrix Reloaded"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In Earth's future, a global crop blight and second Dust Bowl are slowly rendering the planet uninhabitable. Professor Brand (Michael Caine), a brilliant NASA physicist, is working on plans to save mankind by transporting Earth's population to a new home via a wormhole. But first, Brand must send former NASA pilot Cooper (Matthew McConaughey) and a team of researchers through the wormhole and across the galaxy to find out which of three planets could be mankind's new home.",
                            Featured = false,
                            GenreId = 5,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg",
                            Title = "Interstellar"
                        },
                        new
                        {
                            Id = 3,
                            Description = "In 2045 the planet is on the brink of chaos and collapse, but people find salvation in the OASIS: an expansive virtual reality universe created by eccentric James Halliday. When Halliday dies, he promises his immense fortune to the first person to discover a digital Easter egg that's hidden somewhere in the OASIS. When young Wade Watts joins the contest, he finds himself becoming an unlikely hero in a reality-bending treasure hunt through a fantastical world of mystery, discovery and danger.",
                            Featured = false,
                            GenreId = 5,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/74/Ready_Player_One_%28film%29.png",
                            Title = "Ready Player One"
                        },
                        new
                        {
                            Id = 4,
                            Description = "In 1987, Jordan Belfort (Leonardo DiCaprio) takes an entry-level job at a Wall Street brokerage firm. By the early 1990s, while still in his 20s, Belfort founds his own firm, Stratton Oakmont. Together with his trusted lieutenant (Jonah Hill) and a merry band of brokers, Belfort makes a huge fortune by defrauding wealthy investors out of millions. However, while Belfort and his cronies partake in a hedonistic brew of sex, drugs and thrills, the SEC and the FBI close in on his empire of excess.",
                            Featured = false,
                            GenreId = 1,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d8/The_Wolf_of_Wall_Street_%282013%29.png",
                            Title = "The Wolf of Wall Street"
                        },
                        new
                        {
                            Id = 5,
                            Description = "It's been two years since the gang known as the Wolfpack narrowly escaped disaster in Bangkok. Now, Phil (Bradley Cooper), Stu (Ed Helms) and Doug (Justin Bartha) have happy lives at home -- but Alan (Zach Galifianakis) doesn't. Still lacking contentment and a sense of purpose, Alan has gone off his meds and surrendered to his natural impulses. It's up to the other members of the Wolfpack to get him through his personal crisis by embarking on a road trip to the place it all began: Las Vegas.",
                            Featured = true,
                            GenreId = 1,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/15/The_Hangover_Part_3.JPG",
                            Title = "The Hangover Part III"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Captured by smugglers when he was just a hatchling, a macaw named Blu (Lorànt Deutsch) never learned to fly but has a happy domesticated life in Minnesota with Linda (Élisabeth Ventura), who thinks he is the last of his breed.",
                            Featured = false,
                            GenreId = 1,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bb/Rio2011Poster.jpg",
                            Title = "Rio"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
                            Featured = true,
                            GenreId = 2,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/53/Parasite_%282019_film%29.png",
                            Title = "Parasite"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Solitary, cold, methodical and unencumbered by scruples or regrets, a killer waits in the shadows, watching for his next target. Yet, the longer he waits, the more he thinks he's losing his mind, if not his cool.",
                            Featured = false,
                            GenreId = 2,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/32/The_Killer_2023_poster.jpg",
                            Title = "The Killer"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Fleeing a totalitarian country, pregnant Mia must fight for her life when a violent storm knocks the container in which she has been hiding overboard. Trapped, Mia gives birth and is forced to survive to save her baby.",
                            Featured = false,
                            GenreId = 2,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/41/Nowhere_%282023_film%29_poster.jpg",
                            Title = "Nowhere"
                        });
                });

            modelBuilder.Entity("MovieRentalApp.Shared.MovieType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MovieTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "DVD"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Blu-ray"
                        });
                });

            modelBuilder.Entity("MovieRentalApp.Shared.MovieVariant", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("MovieTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("WeekDayPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WeekendPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MovieId", "MovieTypeId");

                    b.HasIndex("MovieTypeId");

                    b.ToTable("MovieVariants");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            MovieTypeId = 2,
                            WeekDayPrice = 6.99m,
                            WeekendPrice = 9.99m
                        },
                        new
                        {
                            MovieId = 2,
                            MovieTypeId = 2,
                            WeekDayPrice = 6.99m,
                            WeekendPrice = 9.99m
                        },
                        new
                        {
                            MovieId = 3,
                            MovieTypeId = 2,
                            WeekDayPrice = 6.99m,
                            WeekendPrice = 9.99m
                        },
                        new
                        {
                            MovieId = 4,
                            MovieTypeId = 2,
                            WeekDayPrice = 6.99m,
                            WeekendPrice = 9.99m
                        },
                        new
                        {
                            MovieId = 5,
                            MovieTypeId = 2,
                            WeekDayPrice = 6.99m,
                            WeekendPrice = 9.99m
                        },
                        new
                        {
                            MovieId = 5,
                            MovieTypeId = 3,
                            WeekDayPrice = 9.99m,
                            WeekendPrice = 11.99m
                        },
                        new
                        {
                            MovieId = 6,
                            MovieTypeId = 2,
                            WeekDayPrice = 6.99m,
                            WeekendPrice = 9.99m
                        },
                        new
                        {
                            MovieId = 7,
                            MovieTypeId = 2,
                            WeekDayPrice = 6.99m,
                            WeekendPrice = 9.99m
                        },
                        new
                        {
                            MovieId = 8,
                            MovieTypeId = 2,
                            WeekDayPrice = 6.99m,
                            WeekendPrice = 9.99m
                        },
                        new
                        {
                            MovieId = 9,
                            MovieTypeId = 2,
                            WeekDayPrice = 6.99m,
                            WeekendPrice = 9.99m
                        },
                        new
                        {
                            MovieId = 9,
                            MovieTypeId = 3,
                            WeekDayPrice = 9.99m,
                            WeekendPrice = 11.99m
                        });
                });

            modelBuilder.Entity("MovieRentalApp.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieRentalApp.Shared.Movie", b =>
                {
                    b.HasOne("MovieRentalApp.Shared.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MovieRentalApp.Shared.MovieVariant", b =>
                {
                    b.HasOne("MovieRentalApp.Shared.Movie", "Movie")
                        .WithMany("Variants")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieRentalApp.Shared.MovieType", "MovieType")
                        .WithMany()
                        .HasForeignKey("MovieTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("MovieType");
                });

            modelBuilder.Entity("MovieRentalApp.Shared.Movie", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
