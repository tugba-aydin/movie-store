using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public List<Cast> Casts { get; set; }
        public Director Director { get; set; }
    }
}
