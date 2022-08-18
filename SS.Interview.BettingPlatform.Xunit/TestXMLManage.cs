using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using System.Xml.Linq;

namespace SS.Interview.BettingPlatform.Xunit
{
    public record Book
    {
       public string Title = "bible";
       public string Author = "judas";
        public string Publisher = "Vatican";
        public double Price = 20.2;
    }
    public class TestXMLManage
    {
        const string xml = @"
            <Bookers>
             <Booker>
              <BookId>KFC</BookId> 
              <Probability>10</Probability>
              <Sport>Football</Sport>  
            </Booker>

             <Booker>
              <BookId>KFC</BookId> 
              <Probability>8</Probability>
              <Sport>Tennis</Sport>  
            </Booker>

            <Booker>
             <BookId>IBM</BookId> 
             <Probability>20</Probability>
             <Sport>Tennis</Sport>  
             </Booker>
 
            <Booker>
             <BookId>Sony</BookId> 
             <Probability>12</Probability>
             <Sport>Tennis</Sport>  
             </Booker>
 
            </Bookers>";

        [Fact]
        public void creatXMLFile()
        {
            var book = new Book();
         //   var filePath = @"c:\temp\books.xml";
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "books.xml");

            // test If exist
            // if not exist create
            // wtite something to it

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("title", book.Title);
                writer.WriteElementString("author", book.Author);
                writer.WriteElementString("publisher", book.Publisher);
                writer.WriteElementString("price", book.Price.ToString());
                writer.WriteEndElement();
                writer.Flush();
            }
             

                Assert.True(File.Exists(filePath));
        }


          


        [Fact]
        public void readXMLwithLinqSport()
        {
            //  var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "list.xml");
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);

            //     var filePath = @"c:\temp\bookMakerList.xml";
            //XElement doc = XElement.Load(filePath);

            XElement doc = XElement.Parse(xml);

            var result = from ed in doc.Descendants("Booker")

                         where ed.Element("BookId").Value == "KFC" && ed.Element("Sport").Value == "Football"

                         select new
                         {

                             BookId = ed.Element("BookId").Value,

                             Sport = ed.Element("Sport").Value,

                             Probability = ed.Element("Probability").Value

                         };


            Assert.NotEmpty(result);

        }




    }
}
