using System;
using System.Security.Policy;
using System.Xml.Linq;
using MovieRentalApp.Shared;

namespace MovieRentalApp.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options ): base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
               .HasKey(ci => new { ci.UserId, ci.MovieId, ci.MovieTypeId });

            modelBuilder.Entity<MovieVariant>()
                .HasKey(p => new { p.MovieId, p.MovieTypeId });

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.MovieId, oi.MovieTypeId });

            modelBuilder.Entity<MovieType>().HasData(
                new MovieType { Id =1, Name = "Default"},
                new MovieType { Id = 2, Name = "DVD" },
                new MovieType { Id = 3, Name = "Blu-ray" }
                );

            modelBuilder.Entity<MovieVariant>().HasData(
                 new MovieVariant
                 {
                     MovieId = 1,
                     MovieTypeId = 2,
                     WeekDayPrice = 6.99m,
                     WeekendPrice = 9.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                    MovieId = 2,
                     MovieTypeId = 2,
                     WeekDayPrice = 6.99m,
                     WeekendPrice = 9.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                    MovieId = 3,
                     MovieTypeId = 2,
                     WeekDayPrice = 6.99m,
                     WeekendPrice = 9.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                    MovieId = 4,
                     MovieTypeId = 2,
                     WeekDayPrice = 6.99m,
                     WeekendPrice = 9.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                    MovieId = 5,
                     MovieTypeId = 2,
                     WeekDayPrice = 6.99m,
                     WeekendPrice = 9.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                     MovieId = 5,
                     MovieTypeId = 3,
                     WeekDayPrice = 9.99m,
                     WeekendPrice = 11.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                    MovieId = 6,
                     MovieTypeId = 2,
                     WeekDayPrice = 6.99m,
                     WeekendPrice = 9.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                    MovieId = 7,
                     MovieTypeId = 2,
                     WeekDayPrice = 6.99m,
                     WeekendPrice = 9.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                    MovieId = 8,
                     MovieTypeId = 2,
                     WeekDayPrice = 6.99m,
                     WeekendPrice = 9.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                    MovieId = 9,
                     MovieTypeId = 2,
                     WeekDayPrice = 6.99m,
                     WeekendPrice = 9.99m,
                     Count = 5
                 },
                 new MovieVariant
                 {
                     MovieId = 9,
                     MovieTypeId = 3,
                     WeekDayPrice = 9.99m,
                     WeekendPrice = 11.99m,
                     Count = 5
                 }
                );


            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Comedy",
                    Url = "comedy"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Thriller",
                    Url = "thriller"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Action",
                    Url = "action"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Rom Com",
                    Url = "rom-com"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Sci-Fi",
                    Url = "sci-fi"
                }
                );

			modelBuilder.Entity<Movie>().HasData(
                    new Movie
                    {
                        Id = 1,
                        Title = "The Matrix Reloaded",
                        Description = "Neo (Keanu Reeves) believes that Morpheus (Laurence Fishburne), an elusive figure considered to be the most dangerous man alive, can answer his question -- What is the Matrix? Neo is contacted by Trinity (Carrie-Anne Moss), a beautiful stranger who leads him into an underworld where he meets Morpheus. They fight a brutal battle for their lives against a cadre of viciously intelligent secret agents. It is a truth that could cost Neo something more precious than his life.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/ba/Poster_-_The_Matrix_Reloaded.jpg",
                        GenreId=5,
                        Featured = true
                    },
                    new Movie
                    {
                        Id = 2,
                        Title = "Interstellar",
                        Description = "In Earth's future, a global crop blight and second Dust Bowl are slowly rendering the planet uninhabitable. Professor Brand (Michael Caine), a brilliant NASA physicist, is working on plans to save mankind by transporting Earth's population to a new home via a wormhole. But first, Brand must send former NASA pilot Cooper (Matthew McConaughey) and a team of researchers through the wormhole and across the galaxy to find out which of three planets could be mankind's new home.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg",
                        GenreId = 5
                    },
                    new Movie
                    {
                        Id = 3,
                        Title = "Ready Player One",
                        Description = "In 2045 the planet is on the brink of chaos and collapse, but people find salvation in the OASIS: an expansive virtual reality universe created by eccentric James Halliday. When Halliday dies, he promises his immense fortune to the first person to discover a digital Easter egg that's hidden somewhere in the OASIS. When young Wade Watts joins the contest, he finds himself becoming an unlikely hero in a reality-bending treasure hunt through a fantastical world of mystery, discovery and danger.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/74/Ready_Player_One_%28film%29.png",
                        GenreId = 5
                    },
                    new Movie
                    {
                        Id = 4,
                        Title = "The Wolf of Wall Street",
                        Description = "In 1987, Jordan Belfort (Leonardo DiCaprio) takes an entry-level job at a Wall Street brokerage firm. By the early 1990s, while still in his 20s, Belfort founds his own firm, Stratton Oakmont. Together with his trusted lieutenant (Jonah Hill) and a merry band of brokers, Belfort makes a huge fortune by defrauding wealthy investors out of millions. However, while Belfort and his cronies partake in a hedonistic brew of sex, drugs and thrills, the SEC and the FBI close in on his empire of excess.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d8/The_Wolf_of_Wall_Street_%282013%29.png",
                        GenreId = 1
                    },
                    new Movie
                    {
                        Id = 5,
                        Title = "The Hangover Part III",
                        Description = "It's been two years since the gang known as the Wolfpack narrowly escaped disaster in Bangkok. Now, Phil (Bradley Cooper), Stu (Ed Helms) and Doug (Justin Bartha) have happy lives at home -- but Alan (Zach Galifianakis) doesn't. Still lacking contentment and a sense of purpose, Alan has gone off his meds and surrendered to his natural impulses. It's up to the other members of the Wolfpack to get him through his personal crisis by embarking on a road trip to the place it all began: Las Vegas.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/15/The_Hangover_Part_3.JPG",
                        GenreId = 1,
                        Featured = true
                    },
                    new Movie
                    {
                        Id = 6,
                        Title = "Rio",
                        Description = "Captured by smugglers when he was just a hatchling, a macaw named Blu (Lorànt Deutsch) never learned to fly but has a happy domesticated life in Minnesota with Linda (Élisabeth Ventura), who thinks he is the last of his breed.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bb/Rio2011Poster.jpg",
                        GenreId = 1
                    },
                    new Movie
                    {
                        Id = 7,
                        Title = "Parasite",
                        Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/53/Parasite_%282019_film%29.png",
                        GenreId = 2,
                        Featured = true
                    },
                    new Movie
                    {
                        Id = 8,
                        Title = "The Killer",
                        Description = "Solitary, cold, methodical and unencumbered by scruples or regrets, a killer waits in the shadows, watching for his next target. Yet, the longer he waits, the more he thinks he's losing his mind, if not his cool.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/32/The_Killer_2023_poster.jpg",
                        GenreId = 2
                    },
                    new Movie
                    {
                        Id = 9,
                        Title = "Nowhere",
                        Description = "Fleeing a totalitarian country, pregnant Mia must fight for her life when a violent storm knocks the container in which she has been hiding overboard. Trapped, Mia gives birth and is forced to survive to save her baby.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/41/Nowhere_%282023_film%29_poster.jpg",
                        GenreId = 2
                    }
                );
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieType> MovieTypes { get; set; }
        public DbSet<MovieVariant> MovieVariants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}

