using Pipewellservice.Helper;
using PipewellserviceJson.HR.Setting;
using PipewellserviceModels.Common;
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
    public class SettingAPIController : BaseController
    {
        SettingJson json = new SettingJson();
        public async Task<JsonResult> DivisionList()
        {
            return new JsonResult
            {
                Data = await json.DivisionList(),
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
        public async Task<JsonResult> RemoveDivision(DeleteDTO data)
        {
            return new JsonResult
            {
                Data = await json.RemoveDivision(data),
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
        public async Task<JsonResult> RemovePosition(DeleteDTO data)
        {
            return new JsonResult
            {
                Data = await json.RemovePosition(data),
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
        public async Task<JsonResult> RemoveDepartment(DeleteDTO data)
        {
            return new JsonResult
            {
                Data = await json.RemoveDepartment(data),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        public async Task<JsonResult> NationalityList()
        {
            return new JsonResult
            {
                Data = await json.NationalityList(),
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
                Data = await json.RemoveUser(ID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        ////////////////////////
        public async Task<JsonResult> ListUserGroups()
        {
            
            return new JsonResult
            {
                Data = await App_Start.AppData.List(ParentEnums.USERGRPOUPS),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<JsonResult> ListGroupNPermissions()
        {

            var result = await json.ListGroupNPermissions();
            result.Pages = await App_Start.AppData.List(ParentEnums.PAGES);
            result.PageGroups = await App_Start.AppData.List(ParentEnums.PAGEGROUPS);

            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateGroupPermissions(PermissionGroup group)
        {
            return new JsonResult
            {
                Data = await json.UpdateGroupPermissions(group),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}