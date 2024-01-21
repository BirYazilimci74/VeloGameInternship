using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Library_Management_System
{
    internal class Library
    {
        public List<Book> books { get; set; }
        public List<Book> myBooks { get; set; }

        private string dataFilePath = "..\\..\\Datas\\LibraryDatas.txt";
        private string myLibraryFile = "..\\..\\Datas\\MyLibrary.txt";
        private static Library instance;

        FileOperations fo = new FileOperations();

        public Library()
        {
            books = new List<Book>();
            myBooks = new List<Book>();
        }
        public static Library getInstance()
        {
            if(instance == null) 
            { 
                instance = new Library();
            }
            return instance;
        }

        public void BarrowBook(Book book)
        {
            if (book.NumberOfCopy > 0)
            {
                book.NumberOfCopy--;
                book.BorrowedCopy++;

                Book newBook = new Book(book.Title, book.Author, book.ISBN, DateTime.Now);
                getInstance().myBooks.Add(newBook);
            }
        }

        public void AddBook(String title, String author, long ISBN, int numberOfCopy, int borrowedCopy)
        {
            Book newBook = new Book(title, author, ISBN, numberOfCopy, borrowedCopy);
            foreach (Book book in getInstance().books)
            {
                if ((book.Title == newBook.Title) && (book.Author == newBook.Author) && (book.ISBN == newBook.ISBN))
                {
                    MessageBox.Show("This book is already in the Library", "Warning", MessageBoxButtons.OK);
                    return;
                }
            }
            getInstance().books.Add(newBook);
        }

        public void ReturnBook(Book book)
        { 
            if (book.BorrowedCopy > 0)
            {
                book.NumberOfCopy++;
                book.BorrowedCopy--;
            }
        }

        public void DisplayBooks(ListView listView)
        {
            fo.PrintFile(dataFilePath, listView);
        }

        public void SearchBook(String strToSearch, List<Book> books, ListView listView)
        {
            listView.Items.Clear();
            foreach (Book book in books)
            {
                if (book.BookInfo().ToLower().Contains(strToSearch.ToLower()))
                {
                    string[] proporties = book.BookInfo().Split('=');
                    listView.Items.Add(new ListViewItem(proporties));
                }
            }
        }

        public void SearchBorrowedBook(String strToSearch, List<Book> books, ListView listView)
        {
            listView.Items.Clear();
            foreach (Book book in books)
            {
                if (book.BorrowedBookInfo().ToLower().Contains(strToSearch.ToLower()))
                {
                    string[] proporties = book.BorrowedBookInfo().Split('=');
                    listView.Items.Add(new ListViewItem(proporties));
                }
            }
        }

        public void SearchOverdue(List<Book> books, ListView listView)
        {
            listView.Items.Clear();
            foreach (Book book in books)
            {
                if (book.returnTime.CompareTo(DateTime.Now) < 0)
                {
                    string[] proporties = book.BorrowedBookInfo().Split('=');
                    listView.Items.Add(new ListViewItem(proporties));
                }
            }
        }
    }
}
