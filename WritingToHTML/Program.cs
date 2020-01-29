using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace WritingToHTML
{
    class Program
    {
        static void Main(string[] args)                                                         //remember to change output path
        {
            /* StringWriter sw = new StringWriter(@"C:\tmp\test\xml");
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                sw.WriteLine("Test");
            }*/

            StringBuilder sampleCreationString = new StringBuilder("");
            StringBuilder CssBuilder = new StringBuilder("");

            #region DownloadingData
            Parallel.Invoke(() =>
            {
                using (FileStream fs = new FileStream(@"HTML_CSS\HTMLPage1.html", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                    {
                        sampleCreationString.Append(sr.ReadToEnd());
                    }
                }
            },
             () =>
                {
                    using (FileStream fs = new FileStream(@"HTML_CSS\Style.css", FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                        {
                            CssBuilder.Append(sr.ReadToEnd());
                        }
                    }
                });
            #endregion


            #region CreateFiles
            Parallel.Invoke(() =>
            {
                using (FileStream fs = new FileStream(@"C:\tmp\test.html", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                    {
                        sw.WriteLine(sampleCreationString);
                    }
                }
            }, () =>
            {
                using (FileStream fs = new FileStream(@"C:\tmp\Style.css", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                    {
                        sw.WriteLine(CssBuilder);
                    }
                }
            });
            #endregion

        }
    }
}
