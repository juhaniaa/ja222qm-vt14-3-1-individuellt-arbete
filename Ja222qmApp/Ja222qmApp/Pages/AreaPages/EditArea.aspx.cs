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

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
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

        // The id parameter name should match the DataKeyNames value set on the control
        public void AreaFormView_UpdateItem(int areaId)
        {
            try
            {
                var area = Service.GetArea(areaId);

                if (area == null)
                {
                    // The area wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", areaId));
                    return;
                }

                TryUpdateModel(area);
                if (ModelState.IsValid)
                {
                    Service.SaveArea(area);

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