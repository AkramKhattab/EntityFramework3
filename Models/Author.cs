using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBackendProject.Models
{
    public class Author
    {
        #region Properties

        // Primary key for the Author entity
        public int Id { get; set; }

        // Name of the author, required field
        [Required]
        public string Name { get; set; }

        // Collection of books associated with this author (Many-to-Many relationship)
        public ICollection<Book> Books { get; set; }

        #endregion
    }
}