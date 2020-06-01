using System;
using System.ComponentModel.DataAnnotations;

namespace SagamoreCarsDAL
{
    public class CarAd
    {
        public int Id { get; set; }
        [Key]
        public string Href { get; set; }
        public int Cost { get; set; }
        public int Year { get; set; }
    }
}
