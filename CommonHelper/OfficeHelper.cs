using Microsoft.Office.Interop.Word;

namespace CommonHelper
{
    public class OfficeHelper
    {
        public static void ConvertWordToPDF(string wordFileName, string pdfFileName)
        {
            Microsoft.Office.Interop.Word.Application wordApp =
            new Microsoft.Office.Interop.Word.Application();
            object missingValue = System.Reflection.Missing.Value;

            wordApp.Visible = false;
            wordApp.ScreenUpdating = false;
            object filename = (object)wordFileName;

            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref filename, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue);

            doc.Activate();

            object outputFileName = pdfFileName;
            object fileFormat = WdSaveFormat.wdFormatPDF;

            doc.SaveAs(ref outputFileName, ref fileFormat, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue,
             ref missingValue, ref missingValue, ref missingValue);

            object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
            ((_Document)doc).Close(ref saveChanges, ref missingValue, ref missingValue);
            doc = null;
            ((_Application)wordApp).Quit(ref missingValue, ref missingValue, ref missingValue);
            wordApp = null;
        }
    }
}
