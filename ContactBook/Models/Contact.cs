using System;

namespace ContactBook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Contact: id = {Id}, name = {Name}, number = {PhoneNumber}.";
        }
    }
}
