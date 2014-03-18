using Ja222qmApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ja222qmApp.Pages
{
    public partial class NewMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }       

        public void MemberFormView_InsertItem(Member member)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // då validering är ok sparas medlemmen
                    // och användaren skickas till sidan med lista på alla medlemmar
                    Service service = new Service();
                    service.SaveMember(member);
                    Session["Sucess"] = "Medlemmen har sparats";
                    Response.RedirectToRoute("Members", null);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle läggas till.");
                }
                

            }
        }        
    }
}