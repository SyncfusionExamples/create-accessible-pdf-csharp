using System;
using System.IO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

namespace word_to_PDF_with_tags
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opens the file as a stream.
            FileStream docStream = new FileStream(@"../../../Data/DocToPDF.doc", FileMode.Open, FileAccess.Read);
            //Loads file stream into Word document.
            using (WordDocument wordDocument = new WordDocument(docStream, Syncfusion.DocIO.FormatType.Automatic))
            {
                using (DocIORenderer render = new DocIORenderer())
                {
                    //Sets true to preserve document-structured tags in the converted PDF document.
                    render.Settings.AutoTag = true;
                    //Converts Word document into PDF document.
                    PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
                    //Saves the PDF file.
                    FileStream outputStream = new FileStream("output.pdf", FileMode.CreateNew);
                    pdfDocument.Save(outputStream);
                    //Closes the instance of PDF document object.
                    pdfDocument.Close(true);
                }
            }
        }
    }
}
