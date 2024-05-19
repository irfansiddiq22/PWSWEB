using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Pipewellservice.Helper
{
    public class DocHelper
    {

        public async Task<bool> ConvertDocument(string FilePath,string SaveFilePath,List<MergeField> mergefields) {
            
            Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
            
            Microsoft.Office.Interop.Word.Document Doc;


            WordApp.Visible = true;


            WordApp.Documents.Open(FilePath);
            Doc = WordApp.ActiveDocument;
            try
            {
                foreach(MergeField field in mergefields)
                {
                    Doc.Content.Find.Execute(FindText: field.Field,  MatchCase:false,Forward:false, ReplaceWith: field.Value, Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll);
                }

                WordApp.ActiveDocument.SaveAs2(SaveFilePath);
                Doc.Close();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

            
        }
    }
}