<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Register assembly="GrapeCity.ActiveReports.Web.v8, Version=8.3.634.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" namespace="GrapeCity.ActiveReports.Web" tagprefix="ActiveReportsWeb" %>
<head id="Head1" runat="server"></head>
<script runat="server">
    void Page_Load()
    {
        ARWebViewer.Report = ViewBag.Report;                   
    }                                                     
</script>

<ActiveReportsWeb:WebViewer ID="ARWebViewer" runat="server" style="margin-left:10px;margin-top:10px" Height="100%" Width="100%">
</ActiveReportsWeb:WebViewer>

