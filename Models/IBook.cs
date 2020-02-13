using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IBook
    {
        public BLL.Book Boek { get; set; }
        // Property signatures:
        // Een Postcode BLL object om de opgehaalde waarden
        // in op te slagen
        string ConnectionString { get; set; }
        // Error message
        string Message { get; set; }

        // method signatures
        public bool Create();
        public bool ReadAll();

    }
}
