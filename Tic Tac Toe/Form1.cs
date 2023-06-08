using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[3, 3];
        bool turn = true; //true is X turn , false is Y turn
        int turnCount = 0, xWin = 0, oWin = 0, tieWin = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //button10 = clear board
        private void button10_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 3;i++)
            {
                for(int j = 0; j < 3;j++)
                {
                    string btnx = "btn" + (i).ToString() + (j).ToString();
                    this.Controls[btnx].Enabled = true;
                    this.Controls[btnx].Text = "";
                }
            }

            //btn00.Text = "";
            //btn00.Enabled = true;
            //btn10.Text = "";
            //btn10.Enabled = true;
            //btn20.Text = "";
            //btn20.Enabled = true;
            //btn01.Text = "";
            //btn01.Enabled = true;
            //btn11.Text = "";
            //btn11.Enabled = true;
            //btn21.Text = "";
            //btn21.Enabled = true;
            //btn02.Text = "";
            //btn02.Enabled = true;
            //btn12.Text = "";
            //btn12.Enabled = true;
            //btn22.Text = "";
            //btn22.Enabled = true;

        }

        private void ticTacToeButtonClicked(Object sender, EventArgs e)
        {
            // assigns the reference of the sender object to button

            Button b = (Button)sender;
            if (turn){
                b.Text = "X";
                //b.ForeColor = Color.Red;
                lblTurn.Text = "Player O's Turn";
            }
            else{
                b.Text = "O";
                lblTurn.Text = "Player X's Turn";
            }
            turn = !turn;
            turnCount++;
            // updates the text of the button that was clicked
            b.Enabled = false;
            //You can get the name of the button that was clicked
            string buttonName = b.Name;
            //label1.Text = buttonName;
            lblXwin.Text = xWin.ToString();
            lblOwin.Text = oWin.ToString();
            lblTie.Text = tieWin.ToString();

            checkWinner();
            
        }

        private void checkWinner()
        {
            bool winner = false;
            if ((btn00.Text == btn01.Text) &&
                (btn01.Text == btn02.Text) && (!btn00.Enabled))
                winner = true;
            if (buttons[1, 0].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[1, 2].Text && !btn10.Enabled)
                winner = true;
            if (buttons[2, 0].Text == buttons[2, 1].Text &&
                buttons[2, 1].Text == buttons[2, 2].Text && !btn20.Enabled)
                winner = true;


            if (buttons[0, 0].Text == buttons[1, 0].Text &&
                buttons[1, 0].Text == buttons[2, 0].Text && !btn20.Enabled)
                winner = true;
            if (buttons[0, 1].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[2, 1].Text && !btn11.Enabled)
                winner = true;
            if (buttons[0, 2].Text == buttons[1, 2].Text &&
                buttons[1, 2].Text == buttons[2, 2].Text && !btn12.Enabled)
                winner = true;


            if (buttons[0, 0].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[2, 2].Text && !btn11.Enabled)
                winner = true;
            if (buttons[0, 2].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[2, 0].Text && !btn11.Enabled)
                winner = true;


            if (winner)
            {
                if (turn)
                    lblOwin.Text = (++oWin).ToString();
                else
                    lblXwin.Text = (++xWin).ToString();

                turnCount = 0;

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        buttons[i, j].Enabled = false;
            }

            if(turnCount == 9)
            {
                tieWin++;
                lblTie.Text = tieWin.ToString();
                lblTurn.Text = "       Tie!";
                turnCount = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTurn.Text = "";
            // buttons.GetLength (0) gives you the amount of rows
            for (int i = 0; i < buttons.GetLength(0); i++)
                // buttons.GetLength (1) gives you the amoung of columns
                for (int j = 0; j < buttons.GetLength(1); j++)
                    buttons[i, j] = (Button)this.Controls["btn" + (i).ToString() + (j).ToString()];

            lblXwin.Text = xWin.ToString();
            lblOwin.Text = oWin.ToString();
            lblTie.Text = tieWin.ToString();
        }
    }
}
