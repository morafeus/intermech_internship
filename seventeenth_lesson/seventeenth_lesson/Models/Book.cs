using System;

namespace seventeenth_lesson.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title; Author = author;
        }
    }
}
