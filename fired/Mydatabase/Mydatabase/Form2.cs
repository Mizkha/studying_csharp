using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Text.RegularExpressions;

namespace Mydatabase
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Mycombo();
            load_table();
            timer1.Start();
            //Mytables();
        }

       
            public string mytab = "goods";
            public string myfstline = "Наименование_товара";
            



        void Mycombo() {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            string Query = "select * from test." + mytab ;
            //string Query = "insert into test.goods (Наименование_товара) values('999');";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                
                while (myReader.Read())
                {
                      string combostring = myReader.GetString(myfstline);
                    //string combostring = myReader.GetString("Наименование_товара");
                    comboBox1.Items.Add(combostring);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void Mytables()
        {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            string Query = "show tables";
            //string Query = "insert into test.goods (Наименование_товара) values('999');";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            // MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            // MySqlDataReader myReader;
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(Query, constring))
            {
                DataTable alltables = new DataTable();
                adapter.Fill(alltables);
                listBox1.DisplayMember = "name";
                listBox1.ValueMember = "id";
                listBox1.DataSource = alltables;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            comboBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false; 
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label9.Visible = false;

            label10.Visible = false; 
            textBox8.Visible = false;

            button4.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            //string Query = "insert into test.goods (Наименование_товара,Код_товара,Дата_упаковки,Срок_годности,Код_еденицы_измерения,Колличество,Цена) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "');";
            string Query1 = "insert into test.goods (Наименование_товара,Код_товара,Дата_упаковки,Срок_годности,Код_еденицы_измерения,Колличество,Цена) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "');";
            

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query1, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            load_table();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            // string Query = "update test.goods set (Наименование_товара='" + this.textBox1.Text + "', Код_товара='" + this.textBox2.Text + "', Дата_упаковки='" + this.textBox3.Text + "', Срок_годности='" + this.textBox4.Text + "', Код_еденицы_измерения='" + this.textBox5.Text + "', Колличество='" + this.textBox6.Text + "', Цена='" + this.textBox7.Text + "');";
            if (listBox1.SelectedItem.ToString() == "Товары")
            {
                string Query2 = "update test.goods set Наименование_товара='" + this.textBox1.Text + "', Код_товара='" + this.textBox2.Text + "', Дата_упаковки='" + this.textBox3.Text + "', Срок_годности='" + this.textBox4.Text + "', Код_еденицы_измерения='" + this.textBox5.Text + "', Колличество='" + this.textBox6.Text + "', Цена='" + this.textBox7.Text + "' where  Код_товара='" + this.textBox2.Text + "' ;";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query2, conDataBase);

                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Updated");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Договоры")
            {
                
                string Query2 = "update test.contracts set Номер_договора='" + this.textBox1.Text + "', Название_фирмы='" + this.textBox2.Text + "', Страна='" + this.textBox3.Text + "', Дата_заключения_договора='" + this.textBox4.Text + "', Код_статуса_оплаты='" + this.textBox5.Text + "' where  Номер_договора='" + this.textBox1.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query2, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Saved");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Заказчики")
            {
                //string constring = "datasource=localhost;port=3306;username=root; password=1234";
                string Query2 = "update test.customers set Название_Фирмы='" + this.textBox1.Text + "', id_фирмы='" + this.textBox2.Text + "', Телефон='" + this.textBox3.Text + "', Страна='" + this.textBox4.Text + "' where  id_фирмы='" + this.textBox2.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query2, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Saved");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Коды статусов оплаты")
            {
                //string constring = "datasource=localhost;port=3306;username=root; password=1234";
                string Query2 = "update test.codes set Вид_статуса_оплаты='" + this.textBox1.Text + "', Описание_статуса_оплаты='" + this.textBox2.Text + "', Код_статуса_оплаты='" + this.textBox3.Text + "' where  Код_статуса_оплаты='" + this.textBox3.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query2, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Saved");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Единицы измерения")
            {
                //string constring = "datasource=localhost;port=3306;username=root; password=1234";
                string Query2 = "update test.measurements set Название_единицы_измерения='" + this.textBox1.Text + "', Тип_единицы_измерения='" + this.textBox2.Text + "', Код_единицы_измерения='" + this.textBox3.Text + "' where  Код_единицы_измерения='" + this.textBox3.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query2, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Saved");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Страны")
            {
                //string constring = "datasource=localhost;port=3306;username=root; password=1234";
                string Query2 = "update test.countries set Код_страны='" + this.textBox1.Text + "', Название_страны='" + this.textBox2.Text + "', Географическое_положение='" + this.textBox3.Text + "' where  Код_страны='" + this.textBox1.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query2, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Saved");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Работники")
            {
                string Query2 = "update test.workers set id='" + this.textBox1.Text + "', name='" + this.textBox2.Text + "', surname='" + this.textBox3.Text + "', age='" + this.textBox4.Text + "', user_name='" + this.textBox5.Text + "', password='" + this.textBox6.Text + "', gender='" + this.textBox7.Text + "', occupation='" + this.textBox8.Text + "' where  id='" + this.textBox1.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query2, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Updated");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            load_table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            if (listBox1.SelectedItem.ToString() == "Товары")
            {
                string Query3 = "delete from test.goods where Код_товара='" + this.textBox2.Text + "' ;";
                //string Query = "insert into test.goods (Наименование_товара) values('999');";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query3, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("deleted");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Договоры")
            {
                //string constring = "datasource=localhost;port=3306;username=root; password=1234";
                string Query3 = "delete from test.contracts where  Номер_договора='" + this.textBox1.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query3, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("deleted");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Заказчики")
            {
                //string constring = "datasource=localhost;port=3306;username=root; password=1234";
                string Query3 = "delete from test.customers where  id_фирмы='" + this.textBox2.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query3, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("deleted");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Коды статусов оплаты")
            {
                //string constring = "datasource=localhost;port=3306;username=root; password=1234";
                string Query3 = "delete from test.codes where  Код_статуса_оплаты='" + this.textBox3.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query3, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("deleted");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Единицы измерения")
            {
                //string constring = "datasource=localhost;port=3306;username=root; password=1234";
                string Query3 = "delete from test.measurements where  Код_единицы_измерения='" + this.textBox3.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query3, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("deleted");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Страны")
            {
                //string constring = "datasource=localhost;port=3306;username=root; password=1234";
                string Query3 = "delete from test.countries where  Код_страны='" + this.textBox1.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query3, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("deleted");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Работники")
            {
                string Query3 = "delete from test.workers where  id='" + this.textBox1.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query3, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("deleted");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            load_table();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string constring = "datasource=localhost;port=3306;username=root; password=1234";
         //   string Query4 = "select * from test.goods where Наименование_товара='" + comboBox1.Text + "' ";
            string Query4 = "select * from test."+mytab+" where "+ myfstline + "='"+ comboBox1.Text +"' ";
            //string Query = "insert into test.goods (Наименование_товара) values('999');";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query4, conDataBase);
            MySqlDataReader myReader;

            if (listBox1.SelectedItem.ToString() == "Товары")
            {

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    while (myReader.Read())
                    {

                        string first_string = myReader.GetString("Наименование_товара");
                        string second_string = myReader.GetInt32("Код_товара").ToString();
                        string third_string = myReader.GetString("Дата_упаковки");
                        string forth_ostring = myReader.GetString("Срок_годности");
                        string fifth_string = myReader.GetInt32("Код_еденицы_измерения").ToString();
                        string sixth_string = myReader.GetInt32("Колличество").ToString();
                        string seventh_string = myReader.GetInt32("Цена").ToString();

                        textBox1.Text = first_string;
                        textBox2.Text = second_string;
                        textBox3.Text = third_string;
                        textBox4.Text = forth_ostring;
                        textBox5.Text = fifth_string;
                        textBox6.Text = sixth_string;
                        textBox7.Text = seventh_string;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (listBox1.SelectedItem.ToString() == "Договоры")
            {

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();

                    while (myReader.Read())
                    {

                        string first_string = myReader.GetInt32("Номер_договора").ToString();
                        string second_string = myReader.GetString("Название_фирмы");
                        string third_string = myReader.GetString("Страна");
                        string forth_ostring = myReader.GetString("Дата_заключения_договора");
                        string fifth_string = myReader.GetInt32("Код_статуса_оплаты").ToString();                       

                        textBox1.Text = first_string;
                        textBox2.Text = second_string;
                        textBox3.Text = third_string;
                        textBox4.Text = forth_ostring;
                        textBox5.Text = fifth_string;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        void load_table() {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select * from test."+ mytab +";", conDataBase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select * from test." + mytab + ";", conDataBase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.label_time.Text = dateTime.ToString();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "Товары")
            {
                label1.Text = "Наименование товара";
                label2.Text = "Код товара";
                label3.Text = "Дата упаковки";
                label4.Text = "Срок годности";
                label5.Text = "Код еденицы измерения";
                label6.Text = "Колличество";
                label7.Text = "Цена";
                dataGridView1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                comboBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label9.Visible = true;

                button4.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;


                label10.Visible = false;
                textBox8.Visible = false;
                mytab = "goods";
                myfstline = "Наименование_товара";
                load_table();


            }

            if (listBox1.SelectedItem.ToString() == "Договоры")
            {
                label1.Text = "Номер договора";
                label2.Text = "Название фирмы";
                label3.Text = "Страна";
                label4.Text = "Дата заключения договора";
                label5.Text = "Код статуса оплаты";
                dataGridView1.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
                textBox7.Visible = false;
                comboBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
                label9.Visible = true;

                button4.Visible = true;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;

                label10.Visible = false;
                textBox8.Visible = false;
                mytab = "contracts";
                myfstline = "Номер_договора";
                load_table();
            }

            if (listBox1.SelectedItem.ToString() == "Заказчики")
            {
                label1.Text = "Название фирмы";
                label2.Text = "id фирмы";
                label3.Text = "Телефон";
                label4.Text = "Страна";
                dataGridView1.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                comboBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label9.Visible = true;

                button4.Visible = false;
                button6.Visible = true;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;

                label10.Visible = false;
                textBox8.Visible = false;
                mytab = "customers";
                myfstline = "Название_фирмы";
                load_table();
            }

            if (listBox1.SelectedItem.ToString() == "Коды статусов оплаты")
            {
                label1.Text = "Вид статуса оплаты";
                label2.Text = "Описание статуса аплаты";
                label3.Text = "Код статуса оплаты";
                dataGridView1.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                comboBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label9.Visible = true;

                button4.Visible = false;
                button6.Visible = false;
                button7.Visible = true;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;

                label10.Visible = false;
                textBox8.Visible = false;
                mytab = "codes";
                myfstline = "Вид_статуса_оплаты";
                load_table();
            }

            if (listBox1.SelectedItem.ToString() == "Единицы измерения")
            {
                label1.Text = "Название единицы измерения";
                label2.Text = "Тип единицы измерения";
                label3.Text = "Код единицы измерения";
                dataGridView1.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                comboBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label9.Visible = true;

                button4.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = true;
                button9.Visible = false;
                button10.Visible = false;

                label10.Visible = false;
                textBox8.Visible = false;
                mytab = "measurements";
                myfstline = "Название_единицы_измерения";
                load_table();
            }

            if (listBox1.SelectedItem.ToString() == "Страны")
            {
                label1.Text = "Код страны";
                label2.Text = "Название страны";
                label3.Text = "Географическое положение";
                dataGridView1.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                comboBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label9.Visible = true;

                button4.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = true;
                button10.Visible = false;

                label10.Visible = false;
                textBox8.Visible = false;
                mytab = "countries";
                myfstline = "Код_страны";
                load_table();
            }

            if (listBox1.SelectedItem.ToString() == "Работники")
            {
                label1.Text = "id";
                label2.Text = "Имя";
                label3.Text = "Фамилия";
                label4.Text = "Возраст";
                label5.Text = "Логин";
                label6.Text = "Пароль";
                label7.Text = "Пол";
                label10.Text = "Проффесия";
                dataGridView1.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                comboBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label9.Visible = true;
                label10.Visible = true;

                button4.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = true;

                mytab = "workers";
                myfstline = "id";
                load_table();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            //string Query = "insert into test.goods (Наименование_товара,Код_товара,Дата_упаковки,Срок_годности,Код_еденицы_измерения,Колличество,Цена) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "');";
            string Query1 = "insert into test.contracts (Номер_договора,Название_фирмы,Страна,Дата_заключения_договора,Код_статуса_оплаты)values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox3.Text + "', '" + this.textBox4.Text + "', '" + this.textBox5.Text + "'); ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query1, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load_table();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            //string Query = "insert into test.goods (Наименование_товара,Код_товара,Дата_упаковки,Срок_годности,Код_еденицы_измерения,Колличество,Цена) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "');";
            string Query1 = "insert into test.customers (Название_Фирмы,id_фирмы,Телефон,Страна)values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox3.Text + "', '" + this.textBox4.Text + "'); ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query1, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load_table();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            //string Query = "insert into test.goods (Наименование_товара,Код_товара,Дата_упаковки,Срок_годности,Код_еденицы_измерения,Колличество,Цена) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "');";
            string Query1 = "insert into test.codes (Вид_статуса_оплаты,Описание_статуса_оплаты,Код_статуса_оплаты)values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox3.Text + "'); ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query1, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load_table();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            //string Query = "insert into test.goods (Наименование_товара,Код_товара,Дата_упаковки,Срок_годности,Код_еденицы_измерения,Колличество,Цена) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "');";
            string Query1 = "insert into test.measurements (Название_единицы_измерения,Тип_единицы_измерения,Код_единицы_измерения)values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox3.Text + "'); ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query1, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load_table();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            //string Query = "insert into test.goods (Наименование_товара,Код_товара,Дата_упаковки,Срок_годности,Код_еденицы_измерения,Колличество,Цена) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "');";
            string Query1 = "insert into test.countries (Код_страны,Название_страны,Географическое_положение)values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox3.Text + "'); ";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query1, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load_table();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root; password=1234";
            //string Query = "insert into test.goods (Наименование_товара,Код_товара,Дата_упаковки,Срок_годности,Код_еденицы_измерения,Колличество,Цена) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "');";
            string Query1 = "insert into test.workers (id,name,surname,age,user_name,password,gender,occupation) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "');";


            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query1, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load_table();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Title = "Save as ExcelFile";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter ="Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 20;
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++) {
                         ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        //ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }

                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();

            }

        }
    }
}
