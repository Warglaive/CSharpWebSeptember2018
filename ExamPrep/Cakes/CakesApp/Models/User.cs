using System;
using System.Collections.Generic;

namespace CakesApp.Models
{
    public class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}