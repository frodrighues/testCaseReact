using System;
using System.Collections.Generic;

namespace testCaseReact.Data
{
    public partial class BistroPermission
    {
        public BistroPermission()
        {
            BistroUser = new HashSet<BistroUser>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<BistroUser> BistroUser { get; set; }
    }
}
