using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public List<User> Users { get; set; }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Role Client => new(1, "client");
        public static Role Admin => new(2, "admin");

        public override string ToString() => Name;

        public static explicit operator int(Role role) => role.Id;
    }
}
