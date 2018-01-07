namespace JixhDb.Models.EntityModels
{
    public class MovieCategory
    {
        public string MovieId { get; set; }
        public Movie Movie { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
