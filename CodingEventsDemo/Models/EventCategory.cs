using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class EventCategory
    { 
        
        public int Id { get; set; }
        public string Name { get; set; }

       

        public EventCategory()
        {

        }
        public EventCategory(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is EventCategory category &&
                   Id == category.Id &&
                   Name == category.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
