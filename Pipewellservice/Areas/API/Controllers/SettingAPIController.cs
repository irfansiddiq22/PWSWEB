using PipewellserviceJson.HR.Setting;
using PipewellserviceModels.HR.Settings;
using PipewellserviceModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.API.Controllers
{
    public class SettingAPIController : Controller
    {
        SettingJson json = new SettingJson();
        public async Task<JsonResult> DivisionList()
        {
            return new JsonResult
            {
                Data =await json.DivisionList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        
        }
        public async Task<JsonResult> UpdateDivision(Division division)
        {
            return new JsonResult
            {
                Data = await json.UpdateDivision(division),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> RemoveDivision(int ID)
        {
            return new JsonResult
            {
                Data = await json.RemoveDivision(ID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }



        public async Task<JsonResult> PositionList()
        {
            return new JsonResult
            {
                Data = await json.PositionList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdatePosition(Position position)
        {
            return new JsonResult
            {
                Data = await json.UpdatePosition(position),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> RemovePosition(int ID)
        {
            return new JsonResult
            {
                Data = await json.RemovePosition(ID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        public async Task<JsonResult> DepartmentList()
        {
            return new JsonResult
            {
                Data = await json.DepartmentList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateDepartment(Department department)
        {
            return new JsonResult
            {
                Data = await json.UpdateDepartment(department),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> RemoveDepartment(int ID)
        {
            return new JsonResult
            {
                Data = await json.RemoveDepartment(ID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        ////////////////////////

        public async Task<JsonResult> UserList()
        {
            return new JsonResult
            {
                Data = await json.UserList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateUser(User user)
        {
            return new JsonResult
            {
                Data = await json.UpdateUser(user),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> RemoveUser(int ID)
        {
            return new JsonResult
            {
                Data = await json.RemoveDepartment(ID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}