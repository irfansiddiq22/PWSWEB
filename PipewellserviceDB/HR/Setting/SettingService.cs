using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SQLHelper;
using PipewellserviceModels.HR.Settings;
using System.Data.SqlClient;
using PipewellserviceModels.User;
using PipewellserviceModels.Common;

namespace PipewellserviceDB.HR.Setting
{
    public class SettingService : DataServices
    {

        public async Task<DataTable> DivisionList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcDivisionList", CommandType.StoredProcedure);
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
        public async Task<DataTable> UpdateDivision(Division division)
        {
            try
            {
                await this.LogUpdate(division.log);
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = division.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = division.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcSaveDivision", CommandType.StoredProcedure, collSP);
                return await DivisionList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<bool> RemoveDivision(DeleteDTO dto)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = dto.ID };
                collSP[1] = new SqlParameter { ParameterName = "@UserName", Value = dto.Name };

                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteDivision", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }



        public async Task<DataTable> PositionList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcPositionList", CommandType.StoredProcedure);
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
        public async Task<DataTable> UpdatePosition(Position position)
        {
            try
            {
                await this.LogUpdate(position.log);
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = position.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = position.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcSavePosition", CommandType.StoredProcedure, collSP);
                return await PositionList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<bool> RemovePosition(DeleteDTO dto)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = dto.ID };
                collSP[1] = new SqlParameter { ParameterName = "@UserName", Value = dto.Name };

                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeletePosition", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }



        public async Task<DataTable> DepartmentList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcDepartmentList", CommandType.StoredProcedure);
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
        public async Task<DataTable> UpdateDepartment(Department department)
        {
            try
            {
                await this.LogUpdate(department.log);
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = department.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = department.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcSaveDepartment", CommandType.StoredProcedure, collSP);
                return await DepartmentList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<bool> RemoveDepartment(DeleteDTO data)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = data.ID };
                collSP[1] = new SqlParameter { ParameterName = "@UserName", Value = data.Name };

                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteDepartment", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }



        public async Task<DataTable> UserList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcUserList", CommandType.StoredProcedure);
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
        public async Task<DataTable> UpdateUser(User user)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = user.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = user.Name };
                collSP[2] = new SqlParameter { ParameterName = "@Password", Value = user.Password };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcSaveUser", CommandType.StoredProcedure, collSP);
                return await UserList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<bool> RemoveUser(int ID)
        {
            try
            {
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteUser", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }


    }
}
