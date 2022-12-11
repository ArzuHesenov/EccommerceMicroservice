using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackage.Entities.Concrete
{
    public class Role : IEntity
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
