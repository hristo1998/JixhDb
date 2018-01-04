using System;

namespace JixhDb.Models.EntittyModels
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public ApplicationUser Comentator { get; set; }

        public Movie Movie { get; set; }

        public DateTime Date { get; set; }
        
    }
}
