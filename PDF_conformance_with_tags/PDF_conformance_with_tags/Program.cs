using System;
using System.IO;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace PDF_conformance_with_tags
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create new PDF document.
            using (PdfDocument doc = new PdfDocument(PdfConformanceLevel.Pdf_A3A))
            {
                //Enable auto-tagging.
                doc.AutoTag = true;
                //Set the document title.
                doc.DocumentInformation.Title = "PDF conformance";
                //Create new page.
                PdfPage page = doc.Pages.Add();
                string text = "Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Washington with 290 employees, several regional sales teams are located throughout their market base.";
                //Initialize the PDF text element.
                PdfTextElement element = new PdfTextElement(text);
                FileStream fontStream = new FileStream(@"../../../Data/Arial.ttf", FileMode.Open, FileAccess.Read);
                PdfFont font = new PdfTrueTypeFont(fontStream, 14);
                //Create font for the text element.
                element.Font = font;
                element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
                //Draw text element with tag.
                element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width, 200));
                FileStream output = new FileStream("PDFA3a.pdf", FileMode.CreateNew);
                //Save the document.
                doc.Save(output);
            }
        }
    }
}
