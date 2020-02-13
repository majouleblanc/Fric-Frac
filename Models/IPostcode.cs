using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IPostcode
    {
        public BLL.Postcode Postcode { get; set; }
        public string Message { get; set; }
        public string ConnectionString { get; set; }

        bool Create();
        bool ReadAll();
    }
}
