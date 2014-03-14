using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Ja222qmApp
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();
            routes.MapPageRoute("Members", "medlemmar", "~/Pages/List.aspx");
            routes.MapPageRoute("MemberDetails", "medlemmar/{id}", "~/Pages/CheckMember.aspx");
            routes.MapPageRoute("NewMember", "nymedlem", "~/Pages/NewMember.aspx");
            routes.MapPageRoute("EditMember", "medlemmar/{id}/redigera", "~/Pages/EditMember.aspx");
            routes.MapPageRoute("DeleteMember", "medlemmar/{id}/radera", "~/Pages/DeleteMember.aspx");

            routes.MapPageRoute("Areas", "ansvar", "~/Pages/AreaPages/ListAreas.aspx");
            routes.MapPageRoute("AreaDetails", "ansvar/{id}", "~/Pages/AreaPages/CheckArea.aspx");
            routes.MapPageRoute("NewArea", "nyttansvar", "~/Pages/AreaPages/NewArea.aspx");
            routes.MapPageRoute("EditArea", "ansvar/{id}/redigera", "~/Pages/AreaPages/EditArea.aspx");
            routes.MapPageRoute("DeleteArea", "ansvar/{id}/radera", "~/Pages/AreaPages/DeleteArea.aspx");
            

        }
    }
}
