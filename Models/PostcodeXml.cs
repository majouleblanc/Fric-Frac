using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DAL
{
    public class PostcodeXml : IPostcode
    {
        // Een Postcode BLL object om de opgehaalde waarden
        // in op te slagen
        public Postcode Postcode { get; set; }
        // Error message
        public string Message { get; set; }
        private string connectionString = @"Data/Postcode";
        public string ConnectionString
        {
            get
            {
                return connectionString + ".xml";
            }
            set
            {
                connectionString = value;
            }
        }
        public PostcodeXml(Postcode postcode)
        {
            Postcode = postcode;
        }
        public PostcodeXml()
        {

        }
        // een overload om de naam van het csv bestand in te stellen
        public PostcodeXml(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// In het geval van XML wordt heel de List gesaved.
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Postcode[]));
                
                TextWriter writer = new StreamWriter(ConnectionString);
                //De serializer werkt niet voor een generieke lijst en ook niet voor ArrayList
                // dus eerst omzetten naar array
                Postcode[] postcodes = Postcode.List.ToArray();
                serializer.Serialize(writer, postcodes);
                writer.Close();
                Message = $"Bestand {ConnectionString} is met succes geserialiseerd.";
                return true;
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                Message = $"Bestand {ConnectionString} is niet geserialiseerd.\nFoutmelding {e.Message}.";
                return false;
            }
        }

        public bool ReadAll()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Postcode[]));
                StreamReader file = new System.IO.StreamReader(ConnectionString);
                Postcode[] postcodes = (Postcode[])serializer.Deserialize(file);
                file.Close();
                // array converteren naar List
                Postcode.List = new List<Postcode>(postcodes);
                Message = $"Bestand {ConnectionString} is met succes gedeserialiseerd.";
                return true;
            }
            catch (Exception e)
            {
                // Melding aan de gebruiker dat iets verkeerd gelopen is.
                // We gebruiken hier de nieuwe mogelijkheid van C# 6: string interpolatie
                Message = $"Het bestand {ConnectionString} s niet gedeserialiseerd.\nFoutmelding {e.Message}.";
                return false;
            }

        }
    }
}
