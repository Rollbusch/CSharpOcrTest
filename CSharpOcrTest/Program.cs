using System.Diagnostics;
using Tesseract;

namespace CSharpOcrTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] images = [
                "Captura de tela 2024-12-18 124720.png",
                "Captura de tela 2024-12-18 124726.png",
                "Captura de tela 2024-12-18 124729.png",
                "Captura de tela 2024-12-18 124732.png",
                "Captura de tela 2024-12-18 124734.png",
                "Captura de tela 2024-12-18 124737.png",
                "Captura de tela 2024-12-18 124740.png",
                "Captura de tela 2024-12-18 124742.png",
                "Captura de tela 2024-12-18 124745.png",
                "Captura de tela 2024-12-18 124755.png",
                "Captura de tela 2024-12-18 124759.png",
                "Captura de tela 2024-12-18 124801.png",
                "Captura de tela 2024-12-18 124804.png",
                "Captura de tela 2024-12-18 124812.png",
                "Captura de tela 2024-12-18 124814.png",
                "Captura de tela 2024-12-18 124817.png",
                "Captura de tela 2024-12-18 124819.png",
                "Captura de tela 2024-12-18 124821.png",
                "Captura de tela 2024-12-18 124827.png",
                "Captura de tela 2024-12-18 124830.png",
                "Captura de tela 2024-12-18 124832.png",
                "Captura de tela 2024-12-18 124836.png",
                "Captura de tela 2024-12-18 124838.png",
            ];

            foreach (string image in images) { 
                ReadText("C:\\Users\\Joao\\Desktop\\Projetos\\CSharpOcrTest\\OCR_test\\"+image);
            }
        }

        private static void ReadText(string testImagePath) {

            try
            {
                //return;
                using (var engine = new TesseractEngine(@"C:\\Users\\Joao\\Desktop\\Projetos\\CSharpOcrTest\\tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

                            Console.WriteLine("Text (GetText): {0}", text);
                            //Console.WriteLine("Text (iterator):");
                            using (var iter = page.GetIterator())
                            {
                                iter.Begin();

                                do
                                {
                                    do
                                    {
                                        do
                                        {
                                            //do
                                            //{
                                            //    if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                            //    {
                                            //        Console.WriteLine("<BLOCK>");
                                            //    }

                                            //    Console.Write(iter.GetText(PageIteratorLevel.Word));
                                            //    Console.Write(" ");

                                            //    if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                            //    {
                                            //        Console.WriteLine();
                                            //    }
                                            //} while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                            //if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                            //{
                                            //    Console.WriteLine();
                                            //}
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Trace.TraceError(e.ToString());
                //Console.WriteLine("Unexpected Error: " + e.Message);
                //Console.Write("Details: ");
                //Console.Write(e.ToString());
            }
            //Console.Write("Press any key to continue . . . ");
            //Console.ReadKey(true);
        }
    }
}