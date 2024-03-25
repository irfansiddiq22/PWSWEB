using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Helper
{
    public class FileHelper
    {
        public async static Task<bool> SaveFile(HttpPostedFileBase file, int FileID, DirectoryNames Dir)
        {
            string extension = Path.GetExtension(file.FileName);

            DirectoryInfo Directory = new DirectoryInfo($"{Config.ResourcesDirectory}\\{Dir.ToString()}");
            if (!Directory.Exists)
            {
                Directory.Create();
            }
            try
            {

                if (System.IO.File.Exists($"{Config.ResourcesDirectory}\\{Dir.ToString()}\\{FileID}{extension}"))
                    System.IO.File.Delete($"{Config.ResourcesDirectory}\\{Dir.ToString()}\\{FileID}{extension}");

                file.SaveAs($"{Config.ResourcesDirectory}\\{Dir.ToString()}\\{FileID}{extension}");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async static Task<string> GetFile(string FileID, DirectoryNames Dir)
        {
            return $"{Config.ResourcesDirectory}\\{Dir.ToString()}\\{FileID}";
            

        }
    }

}