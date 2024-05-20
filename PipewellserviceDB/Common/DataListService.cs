using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Common
{
    public class DataListService : DataServices
    {


        public async Task<DataTable> CountryList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcCountryList", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<DataTable> SponsorList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcSponsorList", CommandType.StoredProcedure);
                DataTable model = new DataTable();
                model.Load(result);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        
        
        public async Task<DataTable> Supervisors()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcSupervisors", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<DataTable> SupervisorList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcSupervisorList", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<DataTable> LeaveTypes()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcLeaveTypes", CommandType.StoredProcedure);
                DataTable model = new DataTable();
                model.Load(result);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<DataTable> EmployeeRequestEmailTemplates()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeRequestEmailTemplates", CommandType.StoredProcedure);
                DataTable model = new DataTable();

                model.Load(result);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<DataTable> EmployeeShortLeaveRequestEmailTemplates()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeShortLeaveRequestEmailTemplates", CommandType.StoredProcedure);
                DataTable model = new DataTable();

                model.Load(result);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
