This is a simple Windows Forms Application for managing a small library system, using C# and .NET Framework.
The application allows users to add, borrow, and return books while maintaining an organized list of available and borrowed books.

Features:
 - Add Books: Users can add books by specifying a unique ID, title, and author. The system ensures that no duplicate IDs are allowed.
 - Borrow Books: A user can borrow a book by providing their name and the book's ID. If the book is already borrowed, the system alerts the user.
 - Return Books: Borrowed books can be returned by the user who borrowed them. Once returned, the books are sorted back into the available books list.
 - Real-time Display: All actions update the UI in real-time, showing the current lists of available and borrowed books in rich text fields.
 - Error Handling: Input validation is included to prevent incorrect or incomplete data from being added (ensuring valid numeric IDs and non-empty fields).
Technologies Used:
 - C# for application logic
 - Windows Forms for the graphical user interface
 - Data Structures:
   * List for storing available and borrowed books.
   * LinkedList for managing the order of books.
   * Dictionary for quick lookup of books by their ID.
  
How to Use:
  - Add a Book: Enter the book's ID, title, and author, then click "Add". The book will appear in the available books list.
  - Borrow a Book: Enter the ID of the book you want to borrow and your username. The book will be moved to the borrowed books list.
  - Return a Book: Enter the book's ID and the same username that borrowed the book. It will be returned and placed back in the available books list, sorted by ID.

Future Enhancements:
 - Search functionality for easier book lookup.
