using System;
using System.Collections.Generic;

namespace testCaseReact.Data
{
    public partial class BistroCredentials
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }

        public BistroUser User { get; set; }
    }
}
