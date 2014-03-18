using Ja222qmApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ja222qmApp.Pages
{
    public partial class DeleteMember : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // hämtar ut länk till sidan med medlems-detaljer från Route
            CancelHyperLink.NavigateUrl = GetRouteUrl("MemberDetails", new { id = Id });

            if (!IsPostBack)
            {
                try
                {
                    // hämta ut medlemsinfo
                    var member = Service.GetMember(Id);
                    if (member != null)
                    {
                        MemberName.Text = member.Name;
                        return;
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

        }      
     
        // då användaren bekräftar radering
        protected void DeleteMemberButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                // radera kund, spara meddelande och
                var id = int.Parse(e.CommandArgument.ToString());
                Service.DeleteMember(id);
                Session["Sucess"] = "Medlemmen har raderats";

                // ...skicka kunden tillbaka till listan med medlemmar
                Response.RedirectToRoute("Members", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett fel inträffade då medlemmen skulle raderas");
            }
        }
    }
}