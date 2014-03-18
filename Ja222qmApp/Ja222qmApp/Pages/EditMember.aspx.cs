using Ja222qmApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ja222qmApp.Pages
{
    public partial class EditMember : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        // hämtar ut medlemsinfo
        public Member MemberFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetMember(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då medlemmen skulle hämtas för redigering");
                return null;
            }
        }

        // används då användaren valt att uppdatera medlemsinfo
        public void MemberFormView_UpdateItem(int memberId)
        {
            try
            {
                // hämta medlems info
                var member = Service.GetMember(memberId);
                
                if (member == null)
                {
                    ModelState.AddModelError("", String.Format("Medlemmen kunde inte hittas"));
                    return;
                }

                TryUpdateModel(member);
                if (ModelState.IsValid)
                {
                    // då valideringen är ok sparas medlemmen och meddelande om lyckad operation
                    Service.SaveMember(member);
                    Session["Sucess"] = "Medlemmen har uppdaterats";

                    // och användaren skickas vidare till den medlemmens detalj sida
                    Response.RedirectToRoute("MemberDetails", new { id = member.MemberId });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", String.Format("Ett fel inträffade då medlemmen skulle uppdateras"));
            }
        }
    }
}