using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace MyXml
{
    //[Serializable]
    public class DataGroup
    {
        public string name;
        public string[] data;

        public DataGroup()
        {
            data = new string[3];
        }
    }

    [Serializable]
    public class Weather
    {  
        public DataGroup[] WeatherData;

        public Weather()
        {
            WeatherData = new DataGroup[8];
        }
    }

    [Serializable]
    public class WeatherII:Weather
    {
       // public int Z { get; set; }
    }

	class Program
	{
		static void Main(string[] args)
		{

            Weather w1 = new Weather();
          /*  w1.name = "Min temp";

            for (int i = 0; i<3; i++)
            {
                w1.data[i] = "temp"+i;
            }*/


			string url = "http://api.pogoda.com/index.php?api_lang=ru&localidad=13088&affiliate_id=4v7j6at7rkya";
			string xml;
			using (var webClient = new WebClient() { Encoding = Encoding.UTF8 })
			{
				xml = webClient.DownloadString(url);
			}
			// ----------------------- CODIROWKA ---------------------------------
			//xml = Encoding.UTF8.GetString( Encoding.UTF8.GetBytes(xml));
			//фикс :)
			//xml = Encoding.UTF8.GetString(/*Encoding.UTF8.GetBytes(xml*/));

			//-------------------------------------------------------------------


			var stringReader = new StringReader(xml);

			var reader = new XmlTextReader(stringReader);
            int groupIndex = 0;
            DataGroup dataGroup = null;
            while (reader.Read())
			{
                bool isName = false;
				if (reader.NodeType == XmlNodeType.Element)
				{
                    if (reader.Name == "name")
                    {
                        reader.Read();

                        dataGroup = new DataGroup();
                        w1.WeatherData[groupIndex] = dataGroup;
                        w1.WeatherData[groupIndex].name = reader.Value;
                        Console.WriteLine($" Name: { reader.Value}");
                        isName = true;
                    }

                    if (reader.Name == "data")
                    {                
                        for (int dataIndex = 0; dataIndex < 3 && reader.Read(); dataIndex++)
                        {
                            //if (dataIndex < 3 && dataGroup != null)
                            {
                                if (dataGroup != null)
                                {
                                    dataGroup.data[dataIndex] = reader.GetAttribute("value");
                                }
                                //Console.WriteLine($" Data1: {reader.Value}");
                                Console.WriteLine($" Data2: {reader.GetAttribute("value")}");
                            }
                        }                     
                    }
                    
				}
                if (isName) groupIndex++;
			}
            //Data to XML
            XmlSerializer x = new XmlSerializer(w1.GetType());

            var file = File.Create("1.txt");
            x.Serialize(file, w1);

            file.Close();

            reader.Close();

            Console.ReadKey();

        }
		

       
	}

}
