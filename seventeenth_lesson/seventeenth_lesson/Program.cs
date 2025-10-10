using seventeenth_lesson.Models;
using System;

namespace seventeenth_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("Harry Potter", "Rouling");
            var book2 = new Book("Война и Мир", "Толстой");
            var book3 = new Book("Зов Ктухлу", "Lavecraft");

            var bookStorage = new Storage<Book>();

            try
            {
                bookStorage.AddItem(book1);
                bookStorage.AddItem(book2);
                bookStorage.AddItem(book3);

                Console.WriteLine(StorageFinder<Book>.FindItem(bookStorage.GetAll(),book => book.Author == "Толстой").Title);

                bookStorage.RemoveItem(book1);

                var books = bookStorage.GetAll();
                foreach(var book in books)
                    Console.WriteLine(book.Title);

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
