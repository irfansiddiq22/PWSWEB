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


            System.IO.File.Copy(@FilePath, SaveFilePath, true);



            using (WordprocessingDocument doc =
                  WordprocessingDocument.Open(SaveFilePath, true))
            {
                try
                {

                    string docText = null;
                    using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                        docText = sr.ReadToEnd();

                    foreach (var t in mergefields)
                    {

                        docText = new Regex($"#{t.Field}#", RegexOptions.IgnoreCase).Replace(docText, (t.Value == null ? "" : t.Value));
                    }
                    using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                        sw.Write(docText);

                    doc.Save();
                }catch (Exception e)
                {

                }
                doc.Dispose();

            }
            return true;
        }

        public async Task<bool> ConvertDocument(string FilePath, string SaveFilePath, List<MergeField> mergefields, List<LoopMergeFieldData> loopData)
        {


            System.IO.File.Copy(@FilePath, SaveFilePath, true);


            
            using (WordprocessingDocument doc =
                  WordprocessingDocument.Open(SaveFilePath, true))
            {
                try
                {

                    string docText = null;
                    using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                        docText = sr.ReadToEnd();

                    foreach (var t in mergefields)
                    {

                        docText = new Regex($"#{t.Field}#", RegexOptions.IgnoreCase).Replace(docText, (t.Value == null ? "" : t.Value));
                    }
                    string Experience = Regex.Match(docText, @"#LOOP#(.+)#ENDLOOP#", RegexOptions.Singleline).Groups[1].Value;
                    Experience = Experience.Substring(Experience.IndexOf("<w:tr"));
                    Experience = Experience.Substring(0, Experience.LastIndexOf("<w:tr "));


                    int LastReplace = Experience.Length;
                    List<string> WorkExp = new List<string>();

                    foreach (LoopMergeFieldData lmd in loopData)
                    {
                        string NewExperienceData = Experience;
                        foreach (var t in lmd.data.mergeFields)
                        {
                            NewExperienceData = new Regex($"#{t.Field}#", RegexOptions.IgnoreCase).Replace(NewExperienceData, (t.Value == null ? "" : t.Value));

                        }
                        WorkExp.Add(NewExperienceData);

                    }
                    //docText.Replace(Experience, string.Join("", WorkExp));

                    int LoopStart = docText.IndexOf("#LOOP#") + 37;

                    docText = docText.Remove(LoopStart, LastReplace).Insert(LoopStart + 1, string.Join("", WorkExp));
                    docText = docText.Replace("#LOOP#", "");
                    docText = docText.Replace("#ENDLOOP#", "");


                    using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                        sw.Write(docText);

                    doc.Save();
                }catch(Exception e)
                {

                }
                doc.Dispose();

            }
            return true;
        }

    }

}