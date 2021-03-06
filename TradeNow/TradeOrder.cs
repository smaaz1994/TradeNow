using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Dynamic;
using System.IO;
using Newtonsoft.Json.Linq;
using TradeNowLibrary;

namespace TradeNow
{
    public partial class TradeOrder : Form
    {


        TraderClass traderOrder = new();        
        public TradeOrder()
        {
            InitializeComponent();
        }

        
 

        private void TradeOrder_Load(object sender, EventArgs e)
        {

        }

        private void createOrder_Click(object sender, EventArgs e)
        {
            

            if (orderBox.Text != null && symbolBox.Text != null && quantityBox.Text != null && routeBox.Text != null && ordertypeBox.Text != null)
            {
       

                traderOrder.OrderID = orderIDbox.TabIndex.ToString();
                traderOrder.Order = orderBox.Text;
                traderOrder.Symbol = symbolBox.Text;
                traderOrder.Quantity = quantityBox.Text;
                traderOrder.Price = priceBox.Text;
                traderOrder.Route = routeBox.Text;
                traderOrder.OrderType = ordertypeBox.Text;
                traderOrder.Tif = tifBox.Text;

                /*orderIDbox.Text = Convert.ToString(traderOrder.OrderID);*/

                string json = JsonConvert.SerializeObject(traderOrder);
                File.WriteAllTextAsync(@"C:\Users\ztech.pk\source\repos\TradeApp\TradeNow\jsondata.json", json);
                MessageBox.Show("Order has been created!");
                using (StreamReader r = new StreamReader(@"C:\Users\ztech.pk\source\repos\TradeApp\TradeNow\jsondata.json"))
                {
                    string jsonFileContent = r.ReadToEnd();
                    var result = JsonConvert.DeserializeObject<TraderClass>(jsonFileContent);
                    var resultList = new List<TraderClass> { result };
                    dataGridView1.DataSource = resultList;
                    
                }
                /*var result = JsonConvert.DeserializeObject<JsonResultClass>(File.ReadAllText(@"C:\Users\ztech.pk\source\repos\TradeApp\TradeNow\jsondata.json"));
                dataGridView1.DataSource = result;*/

            }
            else
            {
                MessageBox.Show("Please Enter All Required attributes!");
            }


        }


        void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            orderBox.ResetText();
            symbolBox.ResetText();
            quantityBox.ResetText();
            priceBox.ResetText();
            routeBox.ResetText();
            ordertypeBox.ResetText();
            tifBox.ResetText();

        }

        private void logout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout Successful!");
            this.Close();
            loginForm main = new loginForm();
            main.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
