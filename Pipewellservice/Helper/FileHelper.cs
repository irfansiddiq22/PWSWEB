﻿using Pipewellservice.App_Start;
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
        public async static Task<bool> SaveFile(HttpPostedFileBase file, int FileID, int ID,DirectoryNames Dir)
        {
            string extension = Path.GetExtension(file.FileName);
            Constant DirectoryToSave = await AppData.Get(ParentValues.RESOURCES,(int) Dir);

            DirectoryToSave.Name = DirectoryToSave.Name.Replace("{ID}", (ID > 0 ? ID.ToString() : ""));

            DirectoryInfo Directory = new DirectoryInfo($"{Config.ResourcesDirectory}\\{DirectoryToSave.Name.ToString()}");
            string FileSavePath = $"{Config.ResourcesDirectory}\\{DirectoryToSave.Name.ToString()}\\{FileID}{extension}";
            
            if (!Directory.Exists)
            {
                Directory.Create();
            }
            try
            {

                if (System.IO.File.Exists(FileSavePath))
                    System.IO.File.Delete(FileSavePath);

                file.SaveAs(FileSavePath);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async static Task<string> GetFile(string FileID,int ID, DirectoryNames Dir)
        {
            try
            {
                Constant DirectoryToSave = await AppData.Get(ParentValues.RESOURCES, (int)Dir);
                string Root= $"{Config.ResourcesDirectory}\\{DirectoryToSave.Name.Replace("{ID}",(ID>0 ? ID.ToString():""))}";
               
                
                return $"{Root}\\{FileID}";
            }
            catch(Exception e)
            {
                return "";
            }

        }
    }

}