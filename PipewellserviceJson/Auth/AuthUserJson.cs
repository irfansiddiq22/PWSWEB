﻿using PipewellserviceDB.Auth;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Auth
{
    public class AuthUserJson
    {

        AuthService service = new AuthService();
        public async Task<User> ProcessLogin(UserAuth user)
        {
            UserAuthSQL result = await service.ProcessLogin(user);
            User model = new User { ID = 0 };
            if (result != null)
                model = (await JsonHelper.Convert<List<User>, DataTable>(result.User)).FirstOrDefault();
            if (model.ID > 0)
            {
                model.Permissions = await JsonHelper.Convert<List<PagePermisson>, DataTable>(result.Permissions);
                model.Supervisors = await JsonHelper.Convert<List<EmployeeSupervisor>, DataTable>(result.Supervisor);
            }
            return model;
        }
        public User ProcessLoginASync(UserAuth user)
        {
            UserAuthSQL result =  service.ProcessLoginAsync(user);
            User model = new User { ID = 0 };
            if (result != null)
                model = (JsonHelper.ConvertASync<List<User>, DataTable>(result.User)).FirstOrDefault();
            if (model.ID > 0)
            {
                model.Permissions =  JsonHelper.ConvertASync<List<PagePermisson>, DataTable>(result.Permissions);
                model.Supervisors =  JsonHelper.ConvertASync<List<EmployeeSupervisor>, DataTable>(result.Supervisor);
            }
            return model;
        }
        public async Task<User>  VerifyOTP(OTP otp)
        {

            UserAuthSQL result = await service.VerifyOTP(otp);
            User model = new User { ID = 0 };
            if (result != null)
                model = (await JsonHelper.Convert<List<User>, DataTable>(result.User)).FirstOrDefault();
            if (model.ID > 0)
            {
                model.Permissions = await JsonHelper.Convert<List<PagePermisson>, DataTable>(result.Permissions);
                model.Supervisors = await JsonHelper.Convert<List<EmployeeSupervisor>, DataTable>(result.Supervisor);
            }
            return model;

        }
        public async Task<string> SaveOTP(OTP otp)
        {
            return await service.SaveOTP(otp);
        }
    }
}
