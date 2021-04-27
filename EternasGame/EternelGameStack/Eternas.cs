using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EternelGameStack
{
    public partial class Eternas : Form
    {
        public Eternas()
        {
            InitializeComponent();
        }

        private void closeBx_Click(object sender, EventArgs e)
        {

            this.Close();
            Application.Exit();

        }

        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {

                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);

            }
        }

        private void topPanel_MouseUp_1(object sender, MouseEventArgs e)
        {

            Move = 0;

        }

        private void topPanel_MouseDown_1(object sender, MouseEventArgs e)
        {

            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;

        }

        private void topPanel_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {

                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);

            }
        }

        private void webPage_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://bakircay.edu.tr");

        }

        private void universityIntagram_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://www.instagram.com/bakircayedu/?hl=tr");

        }

        private void universityTwitter_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://twitter.com/bakircayedu");

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {

            StartGame();

        }

        public void StartGame()
        {
            resultScreen.Clear();

            int status = 0;

            StackSpecifictoEternas Eternas = new StackSpecifictoEternas();

            MyBead Green = new MyBead
            {
                Color = "G"
            };

            MyBead White = new MyBead
            {
                Color = "W"
            };                                        

            for (int i = 0; i < 8; i++) //There are 8 sticks.
            {
                for (int j = 0; j < 2; j++) //There are 2 player. 
                {
                    if (Eternas.allCount < 32 && status == 0) //There are 32 beads and  there is no winner, status is 0
                    {
                        Eternas.Push(White);
                        
                        status = PrintTours(Eternas.Sticks, status);

                        if (status != 1)
                        {
                            Eternas.Push(Green);

                            status = PrintTours(Eternas.Sticks, status);

                        }

                        winnerCheck(resultScreen, status);

                    }

                    if (Eternas.allCount == 32 && status == 0)
                    {
                       
                        resultScreen.Text += "\n" + "The Game ended in a Draw." + "\n";
                        MessageBox.Show("Winning: Draw.", "Winning Colors");

                    }
                }                
            }            
        }
        
        public int PrintTours(object[,] Sticks, int status)
        {
            string allTourResult = "";

            for (int i = 0; i < 8; i++)
            {
                string tourResult = "";

                for (int j = 0; j < 4; j++)
                {
                    tourResult += (string)Sticks[i, j];
                }

                allTourResult += "S" + (i + 1).ToString() + " ---> " + tourResult + "\n";

                if (tourResult == "WWWW")               
                    status = 1;
                
                else if (tourResult == "GGGG")               
                    status = 2;
                
            }

            resultScreen.Text += "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*" + "\n" + allTourResult;
            return status;

        }

        public void winnerCheck(RichTextBox winningResult, int status)
        {
            if (status == 2)
            {
                winningResult.Text += "\n" + "Winning: Green (G)." + "\n";
                MessageBox.Show("Winning: Green (G).", "Winning Colors");


            }                                         
            
            else if (status == 1)
            {

                winningResult.Text += "\n" + "Winning: White (W)." + "\n";
                MessageBox.Show("Winning: White (W).", "Winning Colors");

            }                                      
        }
    }
}
