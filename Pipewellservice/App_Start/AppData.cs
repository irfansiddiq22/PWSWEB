using PipewellserviceJson.HR.Setting;
using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Pipewellservice.App_Start
{
    public class AppData
    {
        public static List<Constant> Constants { get; set; }
        public async static void RegisterConstants()
        {
            Constants = new List<Constant>();
            Constants = await (new SettingJson()).ConstantList();

        }
        public async static Task<Constant> Get(ParentEnums parent,int Enum)
        {
            return Constants.Find(x => x.ParentID ==(int) parent && x.Value == Enum);
        }


    }
}