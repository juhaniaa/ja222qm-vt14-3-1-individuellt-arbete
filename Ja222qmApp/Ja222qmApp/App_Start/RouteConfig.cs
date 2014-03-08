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
            routes.MapPageRoute("EditMember", "medlemmar/{id}/redigera", "~/Pages/EditMember.aspx");
            routes.MapPageRoute("DeleteMember", "medlemmar/{id}/radera", "~/Pages/DeleteMember.aspx");
            

        }
    }
}
