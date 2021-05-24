using System;
using blockbuster.Model.Enum;

namespace blockbuster.Model
{
    public class Media : EntityBase
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private Category Category;
        private bool Status { get; set; }

        public Media(int id, Genre genre, string title, string description, int year, Category category)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Category = category;
            this.Status = false;
        }

        public override string ToString()
        {
            string output = "";
            output += "Genre: " + this.Genre + Environment.NewLine;
            output += "Title: " + this.Title + Environment.NewLine;
            output += "Description: " + this.Description + Environment.NewLine;
            output += "Year: " + this.Year + Environment.NewLine;
            output += "Category: " + this.Category + Environment.NewLine;
            output += "Status: " + this.Status;

            return output;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnDeleted()
        {
            return this.Status;
        }

        public void StatusDeleted() {
            this.Status = true;
        }
        
    }
}