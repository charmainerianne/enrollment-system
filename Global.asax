<%@ Application Language="C#" Inherits="System.Web.HttpApplication" %>

<script runat="server">
    protected void Application_Start(object sender, EventArgs e)
    {
        AreaRegistration.RegisterAllAreas();
        RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        // Add other startup code here if needed
    }
</script>
