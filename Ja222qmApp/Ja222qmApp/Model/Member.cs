using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ja222qmApp.Model
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required(ErrorMessage="Namn måste anges")]
        [StringLength(40, ErrorMessage="Namnet får ha max 40 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Namn måste anges")]
        [StringLength(30, ErrorMessage = "Adressen får ha max 30 tecken.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postnummer måste anges")]
        [StringLength(5, ErrorMessage = "Postnumret får ha max 5 tecken.")]
        public string Postnr { get; set; }

        [Required(ErrorMessage = "Ort måste anges")]
        [StringLength(25, ErrorMessage = "Ort får ha max 25 tecken.")]
        public string City { get; set; }
    }
}