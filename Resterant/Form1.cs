using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace Resterant
{
    public partial class outputSubtotal : Form
    {
        const double QUICHE = 12;
        const double MACARONIWITHOUTCHEESE = 6.50;
        const double GRILLEDPANERABREAD = 5.56;
        const double TAX = 0.13;
        double costOrder;
        double tax;
        double costOrderWithTax;
        double change;
        double tendered;
        double costofQuiche;
        double costofMacaroni;
        double costofGrilled;
        double subtotal;
        int numberofQuiche;
        int numberofMacaroni;
        int numberofGrilled;
        double Tendered;
        double Total;



        public outputSubtotal()
        {
            int reset;
            reset = 0;
            InitializeComponent();
        }

        private void OutputCalculate_Click(object sender, EventArgs e)
        {


            try
            {
                //amount of numbers ordered
                numberofQuiche = Convert.ToInt16(textboxQuiche.Text);
                numberofMacaroni = Convert.ToInt16(textboxMacaroni.Text);
                numberofGrilled = Convert.ToInt16(textboxGrilled.Text);
                //


                costOrder = costofQuiche + costofMacaroni + costofGrilled;
            }

            catch
            {
                outputMessage.Text = "please enter valid number without letters or decimals";
                return;

                //labelSubtotal.Text = numberofQuiche * costofMacaroni * costofGrilled;
            }
            costofQuiche = numberofQuiche * QUICHE;
            costofMacaroni = numberofMacaroni * MACARONIWITHOUTCHEESE;
            costofGrilled = numberofGrilled * GRILLEDPANERABREAD;
            subtotal = costofGrilled + costofMacaroni + costofQuiche;
            tax = subtotal * TAX;


            costOrderWithTax = subtotal + tax;

            labelSubtotal.Text = "Subtotal: " + (subtotal.ToString("C"));
            labelTax.Text = "Tax:        " + (tax.ToString("C"));
            labelTotal.Text = "Total:      " + (costOrderWithTax.ToString("C"));
            


        }

        private void Button1_Click(object sender, EventArgs e)
        {//tnedered money
            try { Tendered = Convert.ToDouble(textboxTendered.Text); }
            catch { outputMessage.Text = "     Enter a valid amount"; }

            Total = costOrderWithTax;
            //money back formula
            change = Tendered - Total;
                
            //channge back
            outputChange2.Text = "Changeback  " + change.ToString("C");
        }

        private void OutputRecipt_Click(object sender, EventArgs e)
        {

            //string for recipt 

            Graphics g = outputLabel.CreateGraphics();
            Font titleFont = new Font("Arial", 20);
            Font drawFont = new Font("Arial", 15);
            Font smallFont = new Font("Arial", 9);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SoundPlayer player = new SoundPlayer(Properties.Resources.printer);
            //title 
            

            player.Play();
            g.DrawString("Tyrones home cooking ", titleFont, blackBrush, 18, 8);
            Thread.Sleep(450);


            //orders
           

            player.Play(); 
            g.DrawString("\n\nQuiche    " + "x" + numberofQuiche + "    " + costofQuiche.ToString("C"), drawFont, blackBrush, 18, 8);
            Thread.Sleep(450);
            player.Play();
            g.DrawString("\n\n\nMacaroni " + "x" + numberofMacaroni +  "    " + costofMacaroni.ToString("C"), drawFont, blackBrush, 18, 8);
            Thread.Sleep(450);
            player.Play();
            g.DrawString("\n\n\n\nBread " + "x" + numberofGrilled + "         " + costofGrilled.ToString("C"), drawFont, blackBrush, 18, 8);

            //subtotal tax and total
            Thread.Sleep(450);
            player.Play();
            g.DrawString("\n\n\n\n\n\nSubtotal          " + subtotal.ToString("C"), drawFont, blackBrush, 18, 8);
            Thread.Sleep(450);
            player.Play();
            g.DrawString("\n\n\n\n\n\n\nTax                 " + tax.ToString("C"), drawFont, blackBrush,18 , 8);
            Thread.Sleep(450);
            player.Play();
            g.DrawString("\n\n\n\n\n\n\n\nTotal               " + Total.ToString("C"), drawFont, blackBrush, 18, 8);
            Thread.Sleep(450);
            player.Play();
            //cash tendered and change back 
            player.Play();
            g.DrawString("\n\n\n\n\n\n\n\n\nTendered        " + Tendered.ToString("C"), drawFont, blackBrush, 18, 8);
            Thread.Sleep(450);
            player.Play();
            g.DrawString("\n\n\n\n\n\n\n\n\n\nCash Back      " + change.ToString("C"), drawFont, blackBrush, 18, 8);
            Thread.Sleep(450);
            player.Play();
            g.DrawString("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nThankyou for coming to tryones home cooking ", smallFont, blackBrush, 18, 8);
            Thread.Sleep(450);
            player.Play();
            g.DrawString("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nCome again or call in ", smallFont, blackBrush, 18, 8);
            //player.Play();
            Thread.Sleep(450);

            g.DrawString("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n519-275-4444 ", smallFont, blackBrush, 18, 8);


        }

        private void NewCustomer_Click(object sender, EventArgs e)
        {
            //graphic settings 
            Graphics g = outputLabel.CreateGraphics();
            g.Clear(Color.White);

            //resetting values 
            textboxQuiche.Text = "";
            textboxGrilled.Text = "";
            textboxMacaroni.Text = "";

            numberofQuiche = 0;
            numberofMacaroni = 0;
            numberofGrilled = 0;

            labelSubtotal.Text = "";
            labelTax.Text = "";
            labelTotal.Text = "";

            textboxTendered.Text = "";
            outputChange2.Text = "";
        }
    }
    }





