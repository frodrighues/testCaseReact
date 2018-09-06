using System;
using System.Collections.Generic;

namespace testCaseReact.Data
{
    public partial class BistroUser
    {
        public BistroUser()
        {
            BistroCredentials = new HashSet<BistroCredentials>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public string Description { get; set; }

        public BistroPermission Permission { get; set; }
        public BistroRole Role { get; set; }
        public ICollection<BistroCredentials> BistroCredentials { get; set; }
    }
}
