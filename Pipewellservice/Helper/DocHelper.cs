using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Pipewellservice.Helper
{
    public class DocHelper
    {

        public async Task<bool> ConvertDocument2(string FilePath, string SaveFilePath, List<MergeField> mergefields)
        {

            Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();

            Microsoft.Office.Interop.Word.Document Doc;


            WordApp.Visible = true;


            WordApp.Documents.Open(FilePath);
            Doc = WordApp.ActiveDocument;
            try
            {
                foreach (MergeField field in mergefields)
                {
                    Doc.Content.Find.Execute(FindText: field.Field, MatchCase: false, Forward: false, ReplaceWith: field.Value, Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll);
                }

                WordApp.ActiveDocument.SaveAs2(SaveFilePath);
                Doc.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }
        public async Task<bool> ConvertDocument(string FilePath, string SaveFilePath, List<MergeField> mergefields)
        {

            //Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();

            //Microsoft.Office.Interop.Word.Document Doc;


            //WordApp.Visible = true;


            //WordApp.Documents.Open(FilePath);
            //Doc = WordApp.ActiveDocument;
            //try
            //{
            //    foreach (MergeField field in mergefields)
            //    {
            //        Doc.Content.Find.Execute(FindText: field.Field, MatchCase: false, Forward: false, ReplaceWith: field.Value, Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll);
            //    }

            //    WordApp.ActiveDocument.SaveAs2(SaveFilePath);
            //    Doc.Close();
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}

            System.IO.File.Copy(@"K:\IrfanUllah\Pipewellservice\Pipewellservice\Resources\Employee\Template\CONTRACT TEMPLATE.doc", @"K:\IrfanUllah\Pipewellservice\Pipewellservice\Resources\Employee\Template\CONTRACT TEMPLATE2.doc", true);


            using (WordprocessingDocument doc =
                  WordprocessingDocument.Open(@"K:\IrfanUllah\Pipewellservice\Pipewellservice\Resources\Employee\Template\CONTRACT TEMPLATE2.doc", true))
            {
                //var body = doc.MainDocumentPart.Document.Body;
                //var paras = body.Elements<Paragraph>();

                //foreach (var para in paras)
                //{
                //    foreach (var run in para.Elements<Run>())
                //    {
                //        foreach (var text in run.Elements<Text>())
                //        {
                //            var field = mergefields.Find(x => x.Field.ToLower() == text.Text.ToLower());
                //            if (field != null)
                //            {
                //                text.Text = text.Text.Replace(text.Text, field.Value);
                //            }
                //        }
                //    }
                //}
                //foreach (var text in doc.MainDocumentPart.Document.Descendants<Text>()){ // <<< Here
                //    var field = mergefields.Find(x => x.Field.ToLower() == text.Text.ToLower());
                //    if (field != null)
                //    {
                //        text.Text = text.Text.Replace(text.Text, field.Value);
                //    }
                //}

                string docText = null;
                using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                    docText = sr.ReadToEnd();

                foreach (var t in mergefields)
                    docText = new Regex(t.Field, RegexOptions.IgnoreCase).Replace(docText, t.Value);

                using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                    sw.Write(docText);
                
                doc.Save();
                doc.Dispose();
                
            }
            return true;
        }

    }

}