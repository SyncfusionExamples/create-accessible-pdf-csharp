using System;
using System.IO;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace create_accessible_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //Create new PDF document.
            using (PdfDocument doc = new PdfDocument())
            {                
                //Set the document title.
                doc.DocumentInformation.Title = "PdfTextElement";
                //Create a new page.
                PdfPage page = doc.Pages.Add();
                //Initialize the structure element with tag type paragraph.
                PdfStructureElement structureElement = new PdfStructureElement(PdfTagType.Paragraph);
                //Represents the text that is the exact replacement for PdfTextElement.
                structureElement.ActualText = "Simple paragraph element";
                string text = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European, and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";
                //Initialize the PDF text element.
                PdfTextElement element = new PdfTextElement(text);
                //Adding tag to the text element.
                element.PdfTag = structureElement;
                //Create font for the text element.
                element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                //Draw text element with tag.
                element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width, 200));
                FileStream output = new FileStream("TaggedPDF.pdf", FileMode.CreateNew);
                //Save the document.
                doc.Save(output);
            }
        }
    }
}
