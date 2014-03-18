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
    public partial class CheckMember : System.Web.UI.Page
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
    
        public Member MemberFormView_GetItem([RouteData]int id)
        {
            try
            {
                // hämtar ut info om medlemmen
                Service service = new Service();
                return service.GetMember(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då medlemmen skulle hämtas");
                return null;
            }
        }


        public IEnumerable<Helper> AreaListView_GetData([RouteData]int id)
        {
            try
            {
                // hämtar ut den specifika medlemmens ansvarsområden
                Service service = new Service();
                return service.GetHelperAreas(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då medlemmens ansvarsområden skulle hämtas ut");
                return null;
            }
        }

        protected void DeleteAreaButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                // medhjälpar id skickas med för att radera ansvarsområdet från medlemmen
                var id = int.Parse(e.CommandArgument.ToString());
                int memberId = Service.DeleteHelperArea(id);

                Response.RedirectToRoute("MemberDetails", new { id = memberId });
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då medlemmens ansvarsområden skulle raderas");
            }
        }

        public IEnumerable<Area> AreaDropDownList_GetData()
        {
            return Service.GetAreas();
        }

        protected void AddAreaButton_Command(object sender, CommandEventArgs e)
        {
            // om inget är valt
            if(int.Parse(AreaDropDownList.SelectedValue) == 0){

                // gör ingenting
                return;
            }

            // medlems id och ansvars id skickas för att lägga till ansvar
            var id = int.Parse(e.CommandArgument.ToString());
            int areaId = int.Parse(AreaDropDownList.SelectedValue);
            Service.AddAreaToMember(id, areaId);

            Response.RedirectToRoute("MemberDetails", new { id = id });
            Context.ApplicationInstance.CompleteRequest();
        }

    }
}