using Pipewellservice.App_Start;
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
        public async static Task<bool> SaveFile(HttpPostedFileBase file, int FileID, int ID, DirectoryNames Dir, string Name = "")
        {
            string extension = Path.GetExtension(file.FileName);
            Constant DirectoryToSave = await AppData.Get(ParentEnums.RESOURCES, (int)Dir);
            string Resouces= DirectoryToSave.Name.Replace("{ID}", (ID > 0 ? ID.ToString() : "")); 
             
            if (Name != "")
            {
                Name = Name.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("|", "");
                Resouces = Resouces.Replace("{Name}", Name);
            }
            DirectoryInfo Directory = new DirectoryInfo($"{Config.ResourcesDirectory}\\{Resouces}");
            string FileSavePath = $"{Config.ResourcesDirectory}\\{Resouces}\\{FileID}{extension}";

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

        public async static Task<string> GetFile(string FileID, int ID, DirectoryNames Dir, string Name = "")
        {
            try
            {
                Constant DirectoryToSave = await AppData.Get(ParentEnums.RESOURCES, (int)Dir);
                string Resouces = DirectoryToSave.Name.Replace("{ID}", (ID > 0 ? ID.ToString() : "")) ;

                if (Name != "")
                {
                    Name = Name.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("|", "");
                    Resouces = Resouces.Replace("{Name}", Name);
                }

                string Root = $"{Config.ResourcesDirectory}\\{Resouces}";

                if (System.IO.File.Exists($"{Root}\\{FileID}"))
                    return $"{Root}\\{FileID}";
                else
                    return "/Content/images/spacer.gif";
            }
            catch (Exception e)
            {
                return "/Content/images/spacer.gif";
            }

        }
        public static string GetFile1(string FileID, int ID, DirectoryNames Dir, string Name = "")
        {
            try
            {
                Constant DirectoryToSave =  AppData.Get1(ParentEnums.RESOURCES, (int)Dir);
                string Resouces = DirectoryToSave.Name.Replace("{ID}", (ID > 0 ? ID.ToString() : ""));

                if (Name != "")
                {
                    Name = Name.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("|", "");
                    Resouces = Resouces.Replace("{Name}", Name);
                }

                string Root = $"{Config.ResourcesDirectory}\\{Resouces}";

                if (System.IO.File.Exists($"{Root}\\{FileID}"))
                    return $"{Root}\\{FileID}";
                else
                    return "/Content/images/spacer.gif";
            }
            catch (Exception e)
            {
                return "/Content/images/spacer.gif";
            }

        }
        public async static Task<string> GetPath(DirectoryNames dir)
        {
            try
            {
                Constant DirectoryToSave = await AppData.Get(ParentEnums.RESOURCES, (int)dir);
                return $"{Config.ResourcesDirectory}\\{DirectoryToSave.Name}";
            }
            catch(Exception e)
            {
                return "";
            }
        }
        public async static Task<string> GetTemplateFile( DirectoryNames Dir, DocTemplates template)
        {
            try
            {
                Constant DirectoryToSave = await AppData.Get(ParentEnums.RESOURCES, (int)Dir);
                Constant Template= await AppData.Get(ParentEnums.DocTemplates, (int)template);

                string Resouces = DirectoryToSave.Name;

                
                string TemplateFile = $"{Config.ResourcesDirectory}\\{Resouces}\\{ Template.Name }";

                if (System.IO.File.Exists(TemplateFile))
                    return TemplateFile;
                else
                    return "";
            }
            catch (Exception e)
            {
                return "";
            }

        }
    }

}