using Ja222qmApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ja222qmApp.Pages.AreaPages
{
    public partial class DeleteArea : System.Web.UI.Page
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
            // länk tillbaka till användarens detalj-sida
            CancelHyperLink.NavigateUrl = GetRouteUrl("AreaDetails", new { id = Id });

            if (!IsPostBack)
            {
                try
                {
                    // hämtar ut ansvarsområdet som skall raderas
                    var area = Service.GetArea(Id);
                    if (area != null)
                    {
                        AreaName.Text = area.AreaName;
                        return;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        // då användaren väljer att radera ansvarsområdet
        protected void DeleteAreaButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                Service.DeleteArea(id);

                // returnerar användaren till sidan med ansvarsområden
                Response.RedirectToRoute("Areas", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett fel inträffade då ansvarsområdet skulle raderas");
            }
        }
    }
}