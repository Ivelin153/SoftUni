namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                // var input = Console.ReadLine();

                //p1 Console.WriteLine(GetBooksByAgeRestriction(db, input));

                //p2 Console.WriteLine(GetGoldenBooks(db));

                //p3 Console.WriteLine(GetBooksByPrice(db));

                //p4 Console.WriteLine(GetBooksNotReleasedIn(db, int.Parse(input)));

                //p5 Console.WriteLine(GetBooksByCategory(db, input));

                //p6 Console.WriteLine(GetBooksReleasedBefore(db, input));

                //p7 Console.WriteLine(GetAuthorNamesEndingIn(db, input));

                //p8 Console.WriteLine(GetBookTitlesContaining(db,input));

                //p9 Console.WriteLine(GetBooksByAuthor(db, input));

                //p10 Console.WriteLine(CountBooks(db, int.Parse(input)));

                //p11 Console.WriteLine(CountCopiesByAuthor(db));

                //p12 Console.WriteLine(GetTotalProfitByCategory(db));

                //p13 Console.WriteLine(GetMostRecentBooks(db));

                //p14 IncreasePrices(db);

                //p15Console.WriteLine(RemoveBooks(db));

            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var result = new StringBuilder();

            var ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);
            var books = context.Books.Where(x => x.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t);

            foreach (var book in books)
            {
                result.AppendLine(book);
            }

            return result.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEdition = (EditionType)Enum.Parse(typeof(EditionType), "Gold", true);
            var result = context.Books
                .Where(b => b.Copies < 5000)
                .Where(b => b.EditionType == goldenEdition)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            return string.Join(Environment.NewLine, result);


        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                });
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var result = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            return string.Join(Environment.NewLine, result);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var listOfCategories = input.ToLower()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

            var bookCategories = context.Books
                .Where(x => x.BookCategories
                    .Select(a => a.Category.Name.ToLower())
                    .Intersect(listOfCategories)
                    .Any())
                    .Select(x => x.Title)
                .OrderBy(x => x);

            return String.Join(Environment.NewLine, bookCategories);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(d => d.ReleaseDate < releaseDate)
                .OrderByDescending(d => d.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                });

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = context.Authors
                .Where(an => an.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a);

            return string.Join(Environment.NewLine, result);

        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b);

            return string.Join(Environment.NewLine, result);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksAuthors = context.Books
                .Include(b => b.Author)
                .Where(ba => ba.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(x => new
                {
                    BookTitle = x.Title,
                    AuthorName = $"{x.Author.FirstName} {x.Author.LastName}"
                });

            var sb = new StringBuilder();

            foreach (var bookAuthor in booksAuthors)
            {
                sb.AppendLine($"{bookAuthor.BookTitle} ({bookAuthor.AuthorName})");
            }

            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var booksCopies = context.Authors
                .Select(x => new
                {
                    FullName = $"{x.FirstName} {x.LastName}",
                    TotalCopies = x.Books.Sum(cop => cop.Copies)
                })
                .OrderByDescending(x => x.TotalCopies)
                .Select(x => $"{x.FullName} - {x.TotalCopies}");

            return string.Join(Environment.NewLine, booksCopies);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    TypeCatecories = x.Name,
                    TotalProfit = x.CategoryBooks.Select(a => a.Book.Price * a.Book.Copies).Sum()
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.TypeCatecories)
                .Select(b => $"{b.TypeCatecories} ${b.TotalProfit}");

            return string.Join(Environment.NewLine, categories);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var bookCategories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    BookCount =
                        x.CategoryBooks
                            .Select(b => b.Book)
                            .Count(),
                    TopThreee =
                        x.CategoryBooks
                            .Select(bc => bc.Book)
                            .OrderByDescending(c => c.ReleaseDate)
                            .Take(3)
                            .Select(s => $"{s.Title} ({s.ReleaseDate.Value.Year})")
                })
                .OrderBy(a => a.Name);

            var sb = new StringBuilder();

            foreach (var v in bookCategories)
            {
                sb.AppendLine("--" + v.Name);
                foreach (var bc in v.TopThreee)
                {
                    sb.AppendLine(bc);
                }
            }
            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncrease = context.Books
               .Where(x => x.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksToIncrease)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {            
            var getBooksWihLessCopies = context.Books
                .Where(x => x.Copies < 4200)
                .ToArray();

            context.RemoveRange(getBooksWihLessCopies);

            context.SaveChanges();

            return getBooksWihLessCopies.Length;
        }

    }

}
