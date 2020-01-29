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
        static void Main(string[] args)
        {
            /* StringWriter sw = new StringWriter(@"C:\tmp\test\xml");
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                sw.WriteLine("Test");
            }*/

            string sampleCreationString = @"
        <html>
        <head>
        Head is here!
        </head>

        <body>
        <h1>Sekcja 4</h1>
        <Table>

            <TR>

                <TH> Broń </TH>

                <TH> Moc<TH>
                <TH> Element </TH>

            </TR>

            <TR>

                <td> ApoCaster </td>

                <td> 431 </ td>

                <td> 0 </td>

            </tr>

            <tr>

                <td> SpecterBuster </td>

                <td> 560 </td>

                <td> 150 </td>

            </tr>

            <tr>

                <td> AmaranthineSlasher </td>

                <td> 700 </td>

                <td> 300 </td>

            <tr>

        </Table> 
        </body>
        </html>";



            using (FileStream fs = new FileStream(@"C:\tmp\test.html", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.WriteLine(sampleCreationString);
                }
            }
        }
    }
}
