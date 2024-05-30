<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Register Assembly="GrapeCity.ActiveReports.Web.v8, Version=8.3.634.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" Namespace="GrapeCity.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<head id="Head1" runat="server"></head>
<script type="text/javascript" src="../../Scripts/jquery-3.7.1.js"></script>
<script runat="server">
    void Page_Load()
    {
        ARWebViewer.Report = ViewBag.Report;
        //ARWebViewer. = ViewBag.ReportName;
    }

</script>
<body>


    <button type="button" style="display:none" onclick="printReport()">Print</button>
    <ActiveReportsWeb:WebViewer ID="ARWebViewer" runat="server" Style="margin-left: 10px; margin-top: 10px;width:100%;height:100%;visibility:visible;" Height="100%" Width="100%" PdfExportOptions-OnlyForPrint="True" ViewerType="AcrobatReader" ValidateRequestMode="Inherit" PdfExportOptions-CenterWindow="False" PdfExportOptions-DisplayMode="None">
    </ActiveReportsWeb:WebViewer>

    <script type="text/javascript">
        function printReport() {

            var viewModel = GetViewModel('1_ARWebViewer');
            // viewModel.Print();
            viewModel.Export(ExportType.Pdf, function () { }, true, { FileName: "report.pdf" });


        };

    </script>

</body>
