using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRentalApp.Server.Migrations
{
    public partial class addMoreMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 5, "Sci-Fi", "sci-fi" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "GenreId", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 4, "In 1987, Jordan Belfort (Leonardo DiCaprio) takes an entry-level job at a Wall Street brokerage firm. By the early 1990s, while still in his 20s, Belfort founds his own firm, Stratton Oakmont. Together with his trusted lieutenant (Jonah Hill) and a merry band of brokers, Belfort makes a huge fortune by defrauding wealthy investors out of millions. However, while Belfort and his cronies partake in a hedonistic brew of sex, drugs and thrills, the SEC and the FBI close in on his empire of excess.", 1, "https://upload.wikimedia.org/wikipedia/en/d/d8/The_Wolf_of_Wall_Street_%282013%29.png", 9.99m, "The Wolf of Wall Street" },
                    { 5, "It's been two years since the gang known as the Wolfpack narrowly escaped disaster in Bangkok. Now, Phil (Bradley Cooper), Stu (Ed Helms) and Doug (Justin Bartha) have happy lives at home -- but Alan (Zach Galifianakis) doesn't. Still lacking contentment and a sense of purpose, Alan has gone off his meds and surrendered to his natural impulses. It's up to the other members of the Wolfpack to get him through his personal crisis by embarking on a road trip to the place it all began: Las Vegas.", 1, "https://upload.wikimedia.org/wikipedia/en/1/15/The_Hangover_Part_3.JPG", 5.99m, "The Hangover Part III" },
                    { 6, "Captured by smugglers when he was just a hatchling, a macaw named Blu (Lorànt Deutsch) never learned to fly but has a happy domesticated life in Minnesota with Linda (Élisabeth Ventura), who thinks he is the last of his breed.", 1, "https://upload.wikimedia.org/wikipedia/en/b/bb/Rio2011Poster.jpg", 7.99m, "Rio" },
                    { 7, "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.", 2, "https://upload.wikimedia.org/wikipedia/en/5/53/Parasite_%282019_film%29.png", 9.99m, "Parasite" },
                    { 8, "Solitary, cold, methodical and unencumbered by scruples or regrets, a killer waits in the shadows, watching for his next target. Yet, the longer he waits, the more he thinks he's losing his mind, if not his cool.", 2, "https://upload.wikimedia.org/wikipedia/en/3/32/The_Killer_2023_poster.jpg", 5.99m, "The Killer" },
                    { 9, "Fleeing a totalitarian country, pregnant Mia must fight for her life when a violent storm knocks the container in which she has been hiding overboard. Trapped, Mia gives birth and is forced to survive to save her baby.", 2, "https://upload.wikimedia.org/wikipedia/en/4/41/Nowhere_%282023_film%29_poster.jpg", 7.99m, "Nowhere" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "GenreId", "ImageUrl", "Title" },
                values: new object[] { "Neo (Keanu Reeves) believes that Morpheus (Laurence Fishburne), an elusive figure considered to be the most dangerous man alive, can answer his question -- What is the Matrix? Neo is contacted by Trinity (Carrie-Anne Moss), a beautiful stranger who leads him into an underworld where he meets Morpheus. They fight a brutal battle for their lives against a cadre of viciously intelligent secret agents. It is a truth that could cost Neo something more precious than his life.", 5, "https://upload.wikimedia.org/wikipedia/en/b/ba/Poster_-_The_Matrix_Reloaded.jpg", "The Matrix Reloaded" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "GenreId", "ImageUrl", "Title" },
                values: new object[] { "In Earth's future, a global crop blight and second Dust Bowl are slowly rendering the planet uninhabitable. Professor Brand (Michael Caine), a brilliant NASA physicist, is working on plans to save mankind by transporting Earth's population to a new home via a wormhole. But first, Brand must send former NASA pilot Cooper (Matthew McConaughey) and a team of researchers through the wormhole and across the galaxy to find out which of three planets could be mankind's new home.", 5, "https://upload.wikimedia.org/wikipedia/en/b/bc/Interstellar_film_poster.jpg", "Interstellar" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "GenreId", "ImageUrl", "Title" },
                values: new object[] { "In 2045 the planet is on the brink of chaos and collapse, but people find salvation in the OASIS: an expansive virtual reality universe created by eccentric James Halliday. When Halliday dies, he promises his immense fortune to the first person to discover a digital Easter egg that's hidden somewhere in the OASIS. When young Wade Watts joins the contest, he finds himself becoming an unlikely hero in a reality-bending treasure hunt through a fantastical world of mystery, discovery and danger.", 5, "https://upload.wikimedia.org/wikipedia/en/7/74/Ready_Player_One_%28film%29.png", "Ready Player One" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "GenreId", "ImageUrl", "Title" },
                values: new object[] { "The Hitchhiker's Guide to the Galaxy[a][b] is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including novels, stage shows, comic books, a 1981 TV series, a 1984 text adventure game, and 2005 feature film.", 1, "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "GenreId", "ImageUrl", "Title" },
                values: new object[] { "\nReady Player One\n\nFirst edition cover\nAuthor	Ernest Cline\nAudio read by	Wil Wheaton\nCountry	United States\nLanguage	English\nSubject	Video games, Virtual Reality\nGenre	LitRPG, science fiction, pop culture fiction, dystopian\nPublisher	Crown Publishing Group\nPublication date	August 16, 2011\nMedia type	Print (hardcover and paperback), e-book, audiobook\nPages	374\nISBN	978-1524763282\nFollowed by	Ready Player Two \nReady Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. ", 1, "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "GenreId", "ImageUrl", "Title" },
                values: new object[] { "Nineteen Eighty-Four (also published as 1984) is a dystopian novel and cautionary tale by English writer George Orwell.", 1, "https://upload.wikimedia.org/wikipedia/en/5/51/1984_first_edition_cover.jpg", "Nineteen Eighty-Four" });
        }
    }
}
