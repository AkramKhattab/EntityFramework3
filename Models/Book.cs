using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBackendProject.Models
{
    public class Book
    {
        #region Properties

        // Primary key for the Book entity
        public int Id { get; set; }

        // Title of the book, required field
        [Required]
        public string Title { get; set; }

        // ISBN (International Standard Book Number) of the book
        public string ISBN { get; set; }

        // Collection of authors associated with this book (Many-to-Many relationship)
        public ICollection<Author> Authors { get; set; }

        // Collection of genres associated with this book (Many-to-Many relationship)
        public ICollection<Genre> Genres { get; set; }

        #endregion
    }
}