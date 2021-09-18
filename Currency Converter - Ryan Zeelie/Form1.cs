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
    public partial class Form1 : Form
    {
        private Currencies curr = new Currencies();
        private Dictionary<string, double> _prices;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _prices = curr.GetCurrencyCollection();

                foreach (var i in _prices)
                {
                    comboBox1.Items.Add(i.Key);
                    comboBox2.Items.Add(i.Key);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No internet connection found, please exit the application and check your internet settings");
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                label1.Text = "Please select a currency from the drop down";
            }
        
            else if (string.IsNullOrEmpty(textBox1.Text) || Convert.ToDouble(textBox1.Text) < 1 )
            {
                label1.Text = "Please enter a valid amount";
            }

            else
            {
                var conversionCalculator = new ConversionCalculator(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), textBox1.Text);

                var conversion = conversionCalculator.ConverterItems(
                    Convert.ToDouble(_prices[conversionCalculator._to]),
                    Convert.ToDouble(_prices[conversionCalculator._from]));
                
                label1.Text = $"{conversionCalculator._amount} {conversionCalculator._from} = {conversion.ToString()} {conversionCalculator._to}  ";

                conversionCalculator._from = null;
                conversionCalculator._to = null;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
