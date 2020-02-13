using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Book
    {


        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        private string publisher;

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private string edition;

        public string Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        private string translator;

        public string Translator
        {
            get { return translator; }
            set { translator = value; }
        }

        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        private static List<Book> list;
        public static List<Book> List
        {
            get { return list; }
            set { list = value; }
        }

        public Book()
        {
            list = new List<Book>();
        }
    }
} 
