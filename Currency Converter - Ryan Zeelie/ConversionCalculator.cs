using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Converter___Ryan_Zeelie
{
    class ConversionCalculator
    {
        public string _from = null;
        public string _to = null;
        public double _amount;

        public ConversionCalculator(string curren1, string curren2, string textBox1)
        {
            // values assigned via the constructor
            _from = curren1;
            _to = curren2;
            _amount = Convert.ToDouble(textBox1);
        }

        public double ConverterItems(double fromCurrency, double toCurrency)
        {
            return Math.Round((fromCurrency / toCurrency)*_amount,2);
        }
    }
}
