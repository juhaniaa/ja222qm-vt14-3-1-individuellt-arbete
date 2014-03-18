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
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Sucess"] != null)
            {
                MessagePlaceholder.Visible = true;
                MessageLiteral.Text = Session["Sucess"].ToString();
                Session.Remove("Sucess");
            }
        }

        // hämtar ut ansvarsområdet med hjälp av idt från route
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

        // hämtar ut de medlemmar som har det specifika ansvaret
        public IEnumerable<Member> AreaMemberListView_GetData([RouteData]int id)
        {
            return Service.GetMembersByArea(id);
        }
    }
}