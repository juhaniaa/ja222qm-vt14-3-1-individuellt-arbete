using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ja222qmApp.Model
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postnr { get; set; }
        public string City { get; set; }
    }
}