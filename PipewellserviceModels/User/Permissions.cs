using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.User
{
    public class PermissionGroupSQL
    {
        public DataTable Groups { get; set;}
        public DataTable Pages { get; set; }

        public PermissionGroupSQL()
        {
            Groups = new DataTable();
            Pages = new DataTable();
        }
    }
    public class PermissionGroupView
    {
        public List<PermissionGroup> Groups { get; set; }
        public List<PagePermisson> Permissions { get; set; }
        public List<Constant> Pages { get; set; }
        public List<Constant> PageGroups { get; set; }


    }

    public class PermissionGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List <PagePermisson> Permissions { get; set; }
        
    }
    public class PagePermisson
    {
        public int PageGroup { get; set; }
        public int GroupID { get; set; }
        public int PageID { get; set; }
        public bool CanWrite { get; set; }
        public bool CanDelete { get; set; }
        public bool CanView { get; set; }
    }
}
