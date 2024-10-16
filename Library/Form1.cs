using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class libraryForm : Form
    {
        private List<Book> bookList;
        private List<Book> returnList;
        private LinkedList<Book> linkedBookList;
        private Dictionary<int, Book> bookDictionary;
        public libraryForm()
        {
            InitializeComponent();
            bookList = new List<Book>();
            returnList = new List<Book>();
            linkedBookList = new LinkedList<Book>();
            bookDictionary = new Dictionary<int, Book>();
        }


        //Method for adding a book
        private void addBook(int id, string title, string author)
        {
            //Checking if the book with the given ID already exists
            if (bookDictionary.ContainsKey(id))
            {
                MessageBox.Show("A book with this ID already exists!");
                return;
            }

            //Creates a new book and adding it into the list
            Book book = new Book { Id = id, Title = title, Author = author };
            bookList.Add(book);
            linkedBookList.AddLast(book);
            bookDictionary[id] = book;
            DisplayBooks();
            idAddBook.Clear();
            titleAddBook.Clear();
            authorAddBook.Clear();
        }

        //Method for returning a book
        private void ReturnBook(int id, string userName)
        {
            //Checking if the book with the given ID exists in the dictionary
            if (bookDictionary.ContainsKey(id))
            {
                Book book = bookDictionary[id];
                if (returnList.Contains(book))
                {
                    if (book.Borrower == userName)
                    {
                        //Remove borrower from book and add back to book list
                        book.Borrower = null;
                        bookList.Add(book);
                        returnList.Remove(book);
                        bookList = bookList.OrderBy(b => b.Id).ToList();//Sorts the list of books by ID
                        DisplayBooks();
                        DisplayReturnList();
                        MessageBox.Show($"The book with this ID {id} has been successfully returned!");
                        richReturnedBooks.AppendText($"Returning a book by a user {userName}: '{book.Title}' by {book.Author}\n");
                    }
                    else
                    {
                        MessageBox.Show("This book is taken by another user!");
                    }
                }
                else
                {
                    MessageBox.Show("The book has already been returned");
                }
            }
            else
            {
                MessageBox.Show("The book with this ID was not found!");
            }
            userReturnBook.Clear();
            idReturnBook.Clear();
        }

        //Method for borrowing a book
        private void BorrowBook(int id, string userName)
        {
            //Checking if the book with the given ID exists
            if (bookDictionary.ContainsKey(id))
            {
                Book borrowedBook = bookDictionary[id];
                if (borrowedBook.Borrower == null)
                {
                    //Adding the book to the list of returned books
                    borrowedBook.Borrower = userName;
                    returnList.Add(borrowedBook);
                    bookList.Remove(borrowedBook);
                    DisplayBooks();
                    DisplayReturnList();
                    richBorrowedBooks.AppendText($"{userName} borrows a book: '{borrowedBook.Title}' by {borrowedBook.Author}\n");
                }
                else
                {
                    MessageBox.Show("The book is already taken!");
                }
            }
            else
            {
                MessageBox.Show("No book found with this ID!");
            }
            userBorrowBook.Clear();
            idBorrowBook.Clear();
        }

        //Method to display the list of available books
        private void DisplayBooks()
        {
            richAddedBooks.Clear();
            foreach (var book in bookList)
            {
                richAddedBooks.AppendText($"{book.Id}: {book.Title} by {book.Author}\n");
            }
        }

        //Method to display the list of returned books
        private void DisplayReturnList()
        {
            richReturnedBooks.Clear();
            foreach (var book in returnList)
            {
                richReturnedBooks.AppendText($"{book.Id}: {book.Title} by {book.Author}\n");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int id;
            //Checking if the ID is a valid number
            if (!int.TryParse(idAddBook.Text, out id))
            {
                MessageBox.Show("Please enter a valid numeric ID!");
                return;
            }

            string title = titleAddBook.Text;
            string author = authorAddBook.Text;

            //Checking if the title is entered
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter the book title!");
                return;
            }

            //Checking if the author is entered
            if (string.IsNullOrWhiteSpace(author))
            {
                MessageBox.Show("Please enter the author!");
                return;
            }
            //Add the book
            addBook(id, title, author);
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            int id;
            //Checking if the ID is a valid number
            if (!int.TryParse(idReturnBook.Text, out id))
            {
                MessageBox.Show("Please enter a valid numeric IDD!");
                return;
            }

            string userName = userReturnBook.Text;
            //Checking if the username is entered
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please enter a username!");
                return;
            }
            //Return the book
            ReturnBook(id, userName);
        }

        private void borrowButton_Click(object sender, EventArgs e)
        {
            int id;
            //Checking if the ID is a valid number
            if (!int.TryParse(idBorrowBook.Text, out id))
            {
                MessageBox.Show("Please enter a valid numeric ID!");
                return;
            }

            string userName = userBorrowBook.Text;
            //Checking if the username is entered
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please enter a username!");
                return;
            }
            //Borrowing the book
            BorrowBook(id, userName);
        }
    }
}
