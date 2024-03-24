using iTextSharp.text.pdf;
using System;
using System.IO;

namespace PDF
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
        public static void unprotectPdf(string input, string output)
        {
            bool passwordProtected = PdfDocument.IsPasswordProtected(input);
            if (passwordProtected)
            {
                string password = null; // retrieve the password somehow

                using (PdfDocument doc = new PdfDocument(input, password))
                {
                    // clear both passwords in order
                    // to produce unprotected document
                    doc.OwnerPassword = "";
                    doc.UserPassword = "";

                    doc.Save(output);
                }
            }
            else
            {
                // no decryption is required
                File.Copy(input, output, true);
            }
        }
    }
}
