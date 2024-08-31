using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBackendProject.Models
{
    public class Genre
    {
        #region Properties

        // Primary key for the Genre entity
        public int Id { get; set; }

        // Name of the genre, required field
        [Required]
        public string Name { get; set; }

        // Collection of books associated with this genre (Many-to-Many relationship)
        public ICollection<Book> Books { get; set; }

        #endregion
    }
}