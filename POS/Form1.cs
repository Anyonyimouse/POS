namespace POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int priceV1 = 0;
        int priceV2 = 0;
        int priceV3 = 0;

        int priceAdd1 = 0;
        int priceAdd2 = 0;
        int priceAdd3 = 0;

        int Total = 0;
        int amount = 0;

        string prod;
        string variety;
        string addOns1;
        int change, cash;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Total = priceV2;
            label1.Text = "Amount: " + Total;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Flavors("Chocolate Chip", "Peanut Butter", "Matcha Green Tea");
            addOns("Walnuts", "coconut flakes", "White chocolate chips");
            Prices(50, 45, 60, 30, 15, 10);
           
            prod = "Cookies";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            label1.Text = "Amount: 0";
            label2.Text = "Change: 0";
            textBox1.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Flavors("Classic French Fries", "Cajun Fries", "Buffalo Fries");
            addOns("Cheese sauce", "truffle oil", " jalapeños");
            Prices(60, 70, 80, 15, 30, 10);
            prod = "Fries";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            label1.Text = "Amount: 0";
            label2.Text = "Change: 0";
            textBox1.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Flavors("Hawain", "Combination (Pepperoni and Ham)", "Triple Chees");
            addOns("Cheese", "Meat", "Ham");
            Prices(125, 150, 145, 20, 20, 15);
            prod = "Pizza";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            label1.Text = "Amount: 0";
            label2.Text = "Change: 0";
            textBox1.Clear();
        }

        void Flavors(string v1, string v2, string v3)
        {
            radioButton1.Text = v1;
            radioButton2.Text = v2;
            radioButton3.Text = v3;


        }

        void addOns(string v1, string v2, string v3)
        {
            checkBox1.Text = v1;
            checkBox2.Text = v2;
            checkBox3.Text = v3;
        }
        void Prices(int p1, int p2, int p3, int a1, int a2, int a3)
        {
            priceV1 = p1;
            priceV2 = p2;
            priceV3 = p3;

            priceAdd1 = a1;
            priceAdd2 = a2;
            priceAdd3 = a3;
        }

        void prices()
        {
            Boolean addons1 = checkBox1.Checked;
            Boolean addons2 = checkBox2.Checked;
            Boolean addons3 = checkBox3.Checked;
            Boolean prod1 = radioButton1.Checked;
            Boolean prod2 = radioButton2.Checked;
            Boolean prod3 = radioButton3.Checked;

            int addons = 0;
            List<string> selectedAddOns = new List<string>();
            List<string> selectedProd = new List<string>();

            if (addons1)
            {
                addons += priceAdd1;
                selectedAddOns.Add(checkBox1.Text);
            }
            if (addons2)
            {
                addons += priceAdd2;
                selectedAddOns.Add(checkBox2.Text);
            }
            if (addons3)
            {
                addons += priceAdd3;
                selectedAddOns.Add(checkBox3.Text);
            }

            if (prod1)
            {
                selectedProd.Add(radioButton1.Text);
            }
            else if (prod2)
            {
                selectedProd.Add(radioButton2.Text);
            }
            else if (prod3)
            {
                selectedProd.Add(radioButton3.Text);
            }
            variety = string.Join(" ", selectedProd);
            addOns1 = string.Join(", ", selectedAddOns);
            amount = addons + Total;
            label1.Text = "Amount: " + amount;


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Total = priceV1;
            label1.Text = "Amount: " + Total;

            variety = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Total = priceV3;
            label1.Text = "Amount: " + Total;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            prices();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            prices();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            prices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            receipt();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            label1.Text = "Amount: 0";
            label2.Text = "Change: 0";
            textBox1.Clear();
        }

        void receipt()
        {
            richTextBox1.Text = richTextBox1.Text 
                +"------------------------------------------------"
                + "You ordered: "
                + prod + "\n"
                + "Flavor: "
                + variety + "\n"
                + "Add Ons: " 
                + addOns1 + "\n"
                + "Price:₱ "
                + amount + "\n" 
                + "You Pay: "
                + cash + "\n"
                + "Total change: "
                + change + "\n"
                + "Thank You For Ordering!" + "\n"
                +"------------------------------------------------";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                cash = Convert.ToInt32(textBox1.Text);
                change =  cash - amount;
                label2.Text = "Change:" + change;
            }
        }
    }
}
