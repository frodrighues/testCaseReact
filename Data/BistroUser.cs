using System;
using System.Collections.Generic;

namespace testCaseReact.Data
{
    public partial class BistroUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionRoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }

        public BistroPermission PermissionRole { get; set; }
        public BistroRole Role { get; set; }
    }
}
