using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public Movie()
        {
            DateAdded = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleasedDate { get; set; }

        public byte NumberInStock { get; set; }



    }
}