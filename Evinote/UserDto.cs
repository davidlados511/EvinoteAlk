using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evinote
{
    public class UserDto
    {
        public UserDto(int id, string username, string email, DateTime created_at, DateTime updated_at)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }

        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}
