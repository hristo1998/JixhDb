using System;

namespace JixhDb.Models.EntittyModels
{
    public class Review
    {

        public int Id { get; set; }

        public string Text { get; set; }

        public Movie Movie { get; set; }

        public ApplicationUser Reviewer { get; set; }

        public DateTime DateTime { get; set; }


        
    }
}
