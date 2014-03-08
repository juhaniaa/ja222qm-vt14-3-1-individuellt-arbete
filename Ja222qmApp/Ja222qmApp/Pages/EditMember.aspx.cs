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
    public partial class EditMember : System.Web.UI.Page
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
        public Ja222qmApp.Model.Member MemberFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetMember(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då kunden skulle hämtas för redigering");
                return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void MemberFormView_UpdateItem(int memberId)
        {

            try
            {
                var member = Service.GetMember(memberId);
                
                if (member == null)
                {
                    // The member wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", memberId));
                    return;
                }

                TryUpdateModel(member);
                if (ModelState.IsValid)
                {
                    Service.SaveMember(member);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}