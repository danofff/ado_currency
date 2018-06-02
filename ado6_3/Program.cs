using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ado6_3
{
    class Program
    {
        public static XDocument doc;
        public static List<curs> data;
        public static Model1 database = new Model1();
        static void Main(string[] args)
        {
            doc = XDocument.Load("http://www.nationalbank.kz/rss/rates.xml");

            /*while (true)
            {
                doc = XDocument.Load("http://www.nationalbank.kz/rss/rates.xml");
                curs = GetData();
                CheckData();
                Thread.Sleep(new TimeSpan(0, 5, 0));
            }*/

            List<curs> data = GetData();
            foreach (var item in data)
            {
                database.curs.Add(item);
            }
            database.SaveChanges();
        }

        public static List<curs> GetData()
        {

            return doc.Element("rss").Element("channel").Elements("item").Select(s => new curs
            {
                dDescription = Double.Parse(s.Element("description").Value.Replace('.',',')),
                title = s.Element("title").Value,
                pubDate = DateTime.Parse(s.Element("pubDate").Value).AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second),          
            }).ToList();

        }
        public static bool CheckData()
        {
            return true;
        }
    }
}
