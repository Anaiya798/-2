using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class BaseProduct
    {
        protected string _title;
        protected int _price;
        protected string _img;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;

            }
        }
        public string Img
        {
            get { return _img; }
            set
            {
                _img = value;

            }
        }

    }
}
