using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using BLL;
namespace DAL
{
    public class BookXml : IBook
    {
        public BLL.Book Boek { get; set; }
        // Een Postcode BLL object om de opgehaalde waarden
        // in op te slagen
        public Book Book { get; set; }
        // Error message
        public string Message { get; set; }
        private string connectionString = @"Data/Book";
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
        public BookXml()
        {

        }
        public BookXml(Book book)
        {
            Book = book;
        }

        // een overload om de naam van het csv bestand in te stellen
        public BookXml(string connectionString)
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
                XmlSerializer serializer = new XmlSerializer(typeof(Book[]));

                TextWriter writer = new StreamWriter(ConnectionString);
                //De serializer werkt niet voor een generieke lijst en ook niet voor ArrayList
                // dus eerst omzetten naar array
                Book[] books = Book.List.ToArray();
                serializer.Serialize(writer, books);
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
                XmlSerializer serializer = new XmlSerializer(typeof(Book[]));
                StreamReader file = new System.IO.StreamReader(ConnectionString);
                Book[] books = (Book[])serializer.Deserialize(file);
                file.Close();
                // array converteren naar List
                Book.List = new List<Book>(books);
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
