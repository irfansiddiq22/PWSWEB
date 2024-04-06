using PipewellserviceDB.HR.Setting;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Settings;
using PipewellserviceModels.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.HR.Setting
{
    public class SettingJson
    {
        SettingService service = new SettingService();

        
        public async Task<List<Constant>> ConstantList()
        {
            return await JsonHelper.Convert<List<Constant>, DataTable>(await service.ConstantList());
        }

        public async Task<List<Division>> DivisionList()
        {
            return await JsonHelper.Convert<List<Division>, DataTable>(await service.DivisionList());
        }
        public async Task<List<Division>> UpdateDivision(Division division)
        {
            return await JsonHelper.Convert<List<Division>, DataTable>(await service.UpdateDivision(division));
        }
        public async Task<bool> RemoveDivision(DeleteDTO dto)
        {
            return await  service.RemoveDivision(dto);
        }



        public async Task<List<Position>> PositionList()
        {
            return await JsonHelper.Convert<List<Position>, DataTable>(await service.PositionList());
        }
        public async Task<List<Position>> UpdatePosition(Position position)
        {
            return await JsonHelper.Convert<List<Position>, DataTable>(await service.UpdatePosition(position));
        }
        public async Task<bool> RemovePosition(DeleteDTO data)
        {
            return await service.RemovePosition(data);
        }


        public async Task<List<Department>> DepartmentList()
        {
            return await JsonHelper.Convert<List<Department>, DataTable>(await service.DepartmentList());
        }
        public async Task<List<Department>> UpdateDepartment(Department department)
        {
            return await JsonHelper.Convert<List<Department>, DataTable>(await service.UpdateDepartment(department));
        }
        public async Task<bool> RemoveDepartment(DeleteDTO data)
        {
            return await service.RemoveDepartment(data);
        }

        public async Task<List<Nationality>> NationalityList()
        {
            return await JsonHelper.Convert<List<Nationality>, DataTable>(await service.NationalityList());
        }

        


        public async Task<List<User>> UserList()
        {
            return await JsonHelper.Convert<List<User>, DataTable>(await service.UserList());
        }
        public async Task<List<User>> UpdateUser(User user)
        {
            return await JsonHelper.Convert<List<User>, DataTable>(await service.UpdateUser(user));
        }
        public async Task<bool> RemoveUser(int ID)
        {
            return await service.RemoveUser(ID);
        }

    }
}
