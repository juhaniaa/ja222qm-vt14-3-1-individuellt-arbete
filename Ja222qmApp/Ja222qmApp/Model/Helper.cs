using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ja222qmApp.Model
{
    public class Helper
    {
        public int HelperId { get; set; }
        public int MemberId { get; set; }
        public int AreaId { get; set; }

        [StringLength(15, ErrorMessage="Ansvarsområdet får vara max 15 tecken")]
        public string HelperAreaName { get; set; }
    }
}