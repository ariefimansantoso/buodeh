using System;
using System.ComponentModel.DataAnnotations;

namespace BuOdeh.Data.Recording
{
    public class Kandang
    {
        [Key]
        public int ID { get; set; }
        public string NoKandang { get; set; }
        public string PopulasiMaks { get; set; }
    }
}
