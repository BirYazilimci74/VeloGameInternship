using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Book
    {
        public String Title { get; set; }
        public String Author { get; set; }
        public long ISBN { get; set; }
        public int NumberOfCopy { get; set; }
        public int BorrowedCopy { get; set; }
        public DateTime borrowedTime { get; set; }
        public DateTime returnTime { get; set; }


        public Book(String title, String author,long ISBN, int numberOfCopy, int borrowedCopy)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = ISBN;
            this.NumberOfCopy = numberOfCopy;
            this.BorrowedCopy = borrowedCopy;
        }

        public Book(String title, String author, long ISBN, DateTime borrowedTime)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = ISBN;
            this.borrowedTime = borrowedTime;
            this.returnTime = borrowedTime.AddHours(1);
        }

        public String BookInfo()
        {
            return this.Title + "=" + this.Author + "=" + this.ISBN + "=" + this.NumberOfCopy + "=" + this.BorrowedCopy;
        }

        public string BorrowedBookInfo()
        {
            return this.Title + "=" + this.Author + "=" + this.ISBN + "=" + this.borrowedTime + "=" + this.returnTime;
        }
    }
}
