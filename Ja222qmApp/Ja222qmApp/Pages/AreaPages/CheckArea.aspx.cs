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
    public partial class CheckArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Area AreaFormView_GetItem([RouteData]int id)
        {
            try
            {
                Service service = new Service();
                return service.GetArea(id);
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett fel inträffade då ansvarsområdet skulle hämtas");
                return null;
            }
        }
    }
}