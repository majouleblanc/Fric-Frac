using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Postcode
    {
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string plaats;
        public string Plaats
        {
            get { return plaats; }
            set { plaats = value; }
        }

        private string provincie;
        public string Provincie
        {
            get { return provincie; }
            set { provincie = value; }
        }

        private string localite;
        public string Localite
        {
            get { return localite; }
            set { localite = value; }
        }

        private string province;
        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        private static List<Postcode> list;
        public static List<Postcode> List
        {
            get { return list; }
            set { list = value; }
        }
        public Postcode()
        {
            List = new List<Postcode>();
        }
    }
}
