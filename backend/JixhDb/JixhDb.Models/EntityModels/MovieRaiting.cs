namespace JixhDb.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class MovieRaiting
    {
        [Key]
        public string Id { get; set; }

        public string Movieid { get; set; }

        public Movie Movie { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        [Range(0, 10)]
        public double Rate { get; set; }
    }
}
