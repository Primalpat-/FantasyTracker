using System;
using System.Collections.Generic;

namespace FantasyTracker.Data.Models
{
    public partial class Manager
    {
        public Manager()
        {
            this.Teams = new List<Team>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
