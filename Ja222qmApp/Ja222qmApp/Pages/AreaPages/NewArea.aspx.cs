using Ja222qmApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ja222qmApp.Pages.AreaPages
{
    public partial class NewArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void AreaFormView_InsertItem(Area area)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // då validering är ok sparas det nya ansvarsområdet
                    Service service = new Service();
                    service.SaveArea(area);

                    // och användaren skickas tillbaka till listan med ansvarsområden
                    Response.RedirectToRoute("Areas", null);
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