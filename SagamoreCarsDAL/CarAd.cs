using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SagamoreCarsDAL
{
    public class CarAd
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Href { get; set; }
        public int Cost { get; set; }
        public int Year { get; set; }
    }
}
