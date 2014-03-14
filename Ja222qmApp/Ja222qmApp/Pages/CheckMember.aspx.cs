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

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Member MemberFormView_GetItem([RouteData]int id)
        {
            try
            {
                Service service = new Service();
                return service.GetMember(id);
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett fel inträffade då medlemmen skulle hämtas");
                return null;
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IEnumerable<Helper> AreaView_GetItem([RouteData]int id)
        {
            try
            {
                Service service = new Service();
                return service.GetHelperAreas(id);
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett fel inträffade då medlemmens ansvarsområden skulle hämtas ut");
                return null;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Helper> AreaListView_GetData([RouteData]int id)
        {
            try
            {
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
                var id = int.Parse(e.CommandArgument.ToString());
                int memberId = Service.DeleteHelperArea(id);

                Response.RedirectToRoute("MemberDetails", new { id = memberId });
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}