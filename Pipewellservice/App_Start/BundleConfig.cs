using System.Web;
using System.Web.Optimization;

namespace Pipewellservice
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/common").Include(
                            "~/Scripts/moment.min.js",
                            "~/Scripts/select2.min.js",
                            "~/Scripts/bootstrap-datepicker.min.js",
                            "~/Scripts/libraries/daterangepicker/daterangepicker.js",
                            "~/Scripts/ProjectScripts/Common/common.js"
                            )
                        );




            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new Bundle("~/lib/sidemenu").Include(
                      "~/Content/libraries/slidemenu/bootsidemenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/treegrid").Include(
                "~/Scripts/libraries/tabletreegrid/jquery.treegrid.js"
                ));

            bundles.Add(new StyleBundle("~/Content/treegrid").Include(
                "~/Scripts/Libraries/tabletreegrid/jquery.treegrid.css"
                ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/css/select2.min.css",
                      "~/Content/bootstrap-datepicker3.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/libraries/slidemenu/bootsidemenu.css",
                      "~/Scripts/libraries/daterangepicker/daterangepicker.css"));

            bundles.Add(new Bundle("~/bundles/sweetalert").Include(
                      "~/Scripts/libraries/sweetalert/sweetalert.min.js"));
            bundles.Add(new StyleBundle("~/bundles/sweetalertcss").Include(
                      "~/Scripts/libraries/sweetalert/sweet-alert.css"));

            bundles.Add(new Bundle("~/bundles/datatable").Include(
                "~/Scripts/datatable.js",
                      "~/Scripts/dataTables.bootstrap5.js"));
            bundles.Add(new StyleBundle("~/bundles/datatablecss").Include(
                      "~/Scripts/libraries/sweetalert/dataTables.bootstrap5.min.css"));

            bundles.Add(new Bundle("~/bundles/pagination").Include(
                      "~/Scripts/libraries/pagination/pagination.js"));
            bundles.Add(new StyleBundle("~/bundles/paginationcss").Include(
                      "~/Scripts/libraries/pagination/pagination.css"));




            bundles.Add(new Bundle("~/lib/setting/setting").Include(
                      "~/Scripts/ProjectScripts/Setting/Setting.js"));
            bundles.Add(new Bundle("~/lib/hr/setting").Include(
                      "~/Scripts/ProjectScripts/HR/Settings/Setting.js"));

            bundles.Add(new Bundle("~/lib/hr/certificate").Include(
                      "~/Scripts/ProjectScripts/HR/Employee/Certificate.js"));

            bundles.Add(new Bundle("~/lib/hr/asset").Include(
                      "~/Scripts/ProjectScripts/HR/Employee/Asset.js"));
            bundles.Add(new Bundle("~/lib/hr/contract").Include(
                      "~/Scripts/ProjectScripts/HR/Employee/Contract.js"));
            bundles.Add(new Bundle("~/lib/hr/employeeid").Include(
                      "~/Scripts/ProjectScripts/HR/Employee/EmployeeID.js"));
            bundles.Add(new Bundle("~/lib/hr/employeefamilyid").Include(
                                  "~/Scripts/ProjectScripts/HR/Employee/EmployeeFamilyID.js"));
            bundles.Add(new Bundle("~/lib/hr/employeefamily").Include(
                                  "~/Scripts/ProjectScripts/HR/Employee/EmployeeFamily.js"));


            bundles.Add(new Bundle("~/lib/hr/employee").Include(
                                  "~/Scripts/ProjectScripts/HR/Employee/Employee.js"));
            bundles.Add(new Bundle("~/lib/hr/employeewarning").Include(
                                  "~/Scripts/ProjectScripts/HR/Employee/EmployeeWarning.js"));
            bundles.Add(new Bundle("~/lib/hr/employeeclearance").Include(
                                  "~/Scripts/ProjectScripts/HR/Employee/EmployeeClearance.js"));
            bundles.Add(new Bundle("~/lib/hr/employeeinquiry").Include(
                                  "~/Scripts/ProjectScripts/HR/Employee/EmployeeInquiry.js"));

            bundles.Add(new Bundle("~/lib/hr/joboffer").Include(
                                  "~/Scripts/ProjectScripts/HR/Employee/JobOffer.js"));
            bundles.Add(new Bundle("~/lib/hr/jobcontract").Include(
                                              "~/Scripts/ProjectScripts/HR/Employee/JobContract.js"));


        }
    }
}
