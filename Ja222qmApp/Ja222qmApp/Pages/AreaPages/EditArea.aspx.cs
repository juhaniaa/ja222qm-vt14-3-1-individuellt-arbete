using Ja222qmApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ja222qmApp.Pages.AreaPages
{
    public partial class EditArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        // hämtar ut det specifika ansvarområdet
        public Area AreaFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetArea(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då ansvarsområdet skulle hämtas för redigering");
                return null;
            }
        }

        // används då användaren valt att uppdatera ansvarsområdet
        public void AreaFormView_UpdateItem(int areaId)
        {
            try
            {
                var area = Service.GetArea(areaId);

                if (area == null)
                {
                    // om ansvarsområdet inte existerar
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", areaId));
                    return;
                }

                TryUpdateModel(area);
                if (ModelState.IsValid)
                {
                    // då valideringen gått igenom sparas ändringarna
                    Service.SaveArea(area);
                    Session["Sucess"] = "Ansvarsområdet har uppdaterats";

                    // och användaren skickas till ansvars-detalj-sidan
                    Response.RedirectToRoute("AreaDetails", new { id = area.AreaId });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", String.Format("Ett fel inträffade då ansvarsområdet skulle uppdateras"));
            }
        }
    }
}