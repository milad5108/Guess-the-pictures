using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        int[] PicRnd = new int[8];
        int[] PicHelpArray = new int[20];
        int[,] BoxRnd = new int[4, 4];
        int[,] BoxHelpArray = new int[4,4];
        int[] PlayerChoosenPic = new int[2];
        int[,] WinningCards = new int[8, 5];

        int Score1 = 0, Score2 = 0;
        int PCDifficult = 0;
        
        bool Player = true, Turn = true;
        bool PlayVsPC = false;
        bool bii = false;
        bool aii = false;
        bool GameEnd = false;

        string[] Pic = new string[16];
        string Player2 = "Player 2";

        Random Rnd = new Random();
        PictureBox PicBox1 = null;
        PictureBox PicBox2 = null;
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Randomize()
        {
            int a = 0;
            bool b = false;
            int j = 0;

            while (j < 8)
            {
                a = Rnd.Next(1, 20);
                if (PicHelpArray[a-1] != 1)
                {
                    PicRnd[j] = a;
                    PicHelpArray[a-1] = 1;
                    j++;
                }
            }
        }

        private void AlignRnd2Pic()
        {
            int[] FirstRndNumber = new int[2];
            int[] SecondRndNumber = new int[2];
            int Count = 0;
            bool SecondNumRight = false;
            try
            {
                while (Count < 8)
                {
                    FirstRndNumber[0] = Rnd.Next(0, 4);
                    SecondRndNumber[0] = Rnd.Next(0, 4);

                    if (BoxHelpArray[FirstRndNumber[0], SecondRndNumber[0]] != 1)
                    {
                        BoxRnd[FirstRndNumber[0], SecondRndNumber[0]] = PicRnd[Count];

                        WinningCards[Count, 0] = FirstRndNumber[0];
                        WinningCards[Count, 1] = SecondRndNumber[0];

                        BoxHelpArray[FirstRndNumber[0], SecondRndNumber[0]] = 1;
                        SecondNumRight = false;

                        while (SecondNumRight == false)
                        {
                            FirstRndNumber[1] = Rnd.Next(0, 4);
                            SecondRndNumber[1] = Rnd.Next(0, 4);
                            if (BoxHelpArray[FirstRndNumber[1], SecondRndNumber[1]] != 1)
                            {
                                BoxRnd[FirstRndNumber[1], SecondRndNumber[1]] = PicRnd[Count];

                                WinningCards[Count, 2] = FirstRndNumber[1];
                                WinningCards[Count, 3] = SecondRndNumber[1];

                                BoxHelpArray[FirstRndNumber[1], SecondRndNumber[1]] = 1;
                                Count++;
                                SecondNumRight = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                Application.Restart();
            }
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            Randomize();
            AlignRnd2Pic();

            lblPlayer.Text = "Player 1's Turn";
            lblscore1.Text = Score1.ToString();
            lblscore2.Text = Score2.ToString();

            this.Width = 459;
        }

       private void PlayerPlay()
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
       {
           PicBox1.Image = Memory_Game.Properties.Resources.Null;
           PicBox2.Image = Memory_Game.Properties.Resources.Null;
           PicBox1.Enabled = true;
           PicBox2.Enabled = true;
           if (Player2 == "PC" && Player==false)
           {
               timer3.Enabled = true;
           }
            timer1.Enabled = false;
        }
       
        private void Score()
        {
            if (Player == true)
            {
                Score2 += 10;
                lblscore2.Text = Score2.ToString();
                Player = false;
                lblPlayer.Text = "Player 2's Turn";
            }
            else
            {
                Score1 += 10;
                lblscore1.Text = Score1.ToString();
                Player = true;
                lblPlayer.Text = "Player 1's Turn";
            }
        }

        
        private void vsCumputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayVsPC = vsCumputerToolStripMenuItem.Checked;
            
        }

        private void vsPlayer2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vsPlayer2ToolStripMenuItem.Checked == true)
            {
                vsCumputerToolStripMenuItem.Checked = false;
                btnPlayMode.Image = Memory_Game.Properties.Resources.Person;
                this.Text = "Memory Game (Vs. Player 2)";
            }
            else
            {
                vsCumputerToolStripMenuItem.Checked = true;
                btnPlayMode.Image = Memory_Game.Properties.Resources.PC;
                this.Text = "Memory Game (Vs. Computer)";
            }
            }

      

        /*private void PCPlay()
        {
            int PCChoice1, PCChoice2;
            PCChoice1 = Rnd.Next(1, 16);
            PickPCPic(PCChoice1);
            PCChoice2 = Rnd.Next(1, 16);
            PickPCPic(PCChoice2);

            PlayerPlay();
        }
          */

        /*
        private void PickPCPic(int PC)
        {
            switch (PC)
            {
                case 1:
                    if (Turn == false)
                    {
                        Selected1[0] = 1;
                        Select1 = Pic[0];
                    }
                    else
                    {
                        Selected2[0] = 1;
                        Select2 = Pic[0];
                    }
                    break;
                case 2:
                    N2.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 2;
                        Select1 = Pic[1];
                    }
                    else
                    {
                        Selected2[0] = 2;
                        Select2 = Pic[1];
                    }
                    break;
                case 3:
                    N3.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 3;
                        Select1 = Pic[2];
                    }
                    else
                    {
                        Selected2[0] = 3;
                        Select2 = Pic[2];
                    }
                    break;
                case 4:
                    N4.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 4;
                        Select1 = Pic[3];
                    }
                    else
                    {
                        Selected2[0] = 4;
                        Select2 = Pic[3];
                    }
                    break;
                case 5:
                    N5.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 5;
                        Select1 = Pic[4];
                    }
                    else
                    {
                        Selected2[0] = 5;
                        Select2 = Pic[4];
                    }
                    break;
                case 6:
                    N6.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 6;
                        Select1 = Pic[5];
                    }
                    else
                    {
                        Selected2[0] = 6;
                        Select2 = Pic[5];
                    }
                    break;
                case 7:
                    N7.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 7;
                        Select1 = Pic[6];
                    }
                    else
                    {
                        Selected2[0] = 7;
                        Select2 = Pic[6];
                    }
                    break;
                case 8:
                    N8.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 8;
                        Select1 = Pic[7];
                    }
                    else
                    {
                        Selected2[0] = 8;
                        Select2 = Pic[7];
                    }
                    break;
                case 9:
                    N9.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 9;
                        Select1 = Pic[8];
                    }
                    else
                    {
                        Selected2[0] = 9;
                        Select2 = Pic[8];
                    }
                    break;
                case 10:
                    N10.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 10;
                        Select1 = Pic[9];
                    }
                    else
                    {
                        Selected2[0] = 10;
                        Select2 = Pic[9];
                    }
                    break;
                case 11:
                    N11.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 11;
                        Select1 = Pic[10];
                    }
                    else
                    {
                        Selected2[0] = 11;
                        Select2 = Pic[10];
                    }
                    break;
                case 12:
                    N1.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 12;
                        Select1 = Pic[11];
                    }
                    else
                    {
                        Selected2[0] = 12;
                        Select2 = Pic[11];
                    }
                    break;
                case 13:
                    N13.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 13;
                        Select1 = Pic[12];
                    }
                    else
                    {
                        Selected2[0] = 13;
                        Select2 = Pic[12];
                    }
                    break;
                case 14:
                    N14.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 14;
                        Select1 = Pic[13];
                    }
                    else
                    {
                        Selected2[0] = 14;
                        Select2 = Pic[13];
                    }
                    break;
                case 15:
                    N15.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 15;
                        Select1 = Pic[14];
                    }
                    else
                    {
                        Selected2[0] = 15;
                        Select2 = Pic[14];
                    }
                    break;
                case 16:
                    N16.Hide();
                    if (Turn == false)
                    {
                        Selected1[0] = 16;
                        Select1 = Pic[15];
                    }
                    else
                    {
                        Selected2[0] = 16;
                        Select2 = Pic[15];
                    }
                    break;

            }
        }*/

        private Image ShowChoosenPic(int First, int Second)
        {
            Image PicName = null;

            switch (BoxRnd[First, Second])
            {
                case 1:
                    PicName = Memory_Game.Properties.Resources.p1;
                    break;
                case 2:
                    PicName = Memory_Game.Properties.Resources.p2;
                    break;
                case 3:
                    PicName = Memory_Game.Properties.Resources.p3;
                    break;
                case 4:
                    PicName = Memory_Game.Properties.Resources.p4;
                    break;
                case 5:
                    PicName = Memory_Game.Properties.Resources.p5;
                    break;
                case 6:
                    PicName = Memory_Game.Properties.Resources.p6;
                    break;
                case 7:
                    PicName = Memory_Game.Properties.Resources.p7;
                    break;
                case 8:
                    PicName = Memory_Game.Properties.Resources.p8;
                    break;
                case 9:
                    PicName = Memory_Game.Properties.Resources.p9;
                    break;
                case 10:
                    PicName = Memory_Game.Properties.Resources.p10;
                    break;
                case 11:
                    PicName = Memory_Game.Properties.Resources.p11;
                    break;
                case 12:
                    PicName = Memory_Game.Properties.Resources.p12;
                    break;
                case 13:
                    PicName = Memory_Game.Properties.Resources.p13;
                    break;
                case 14:
                    PicName = Memory_Game.Properties.Resources.p14;
                    break;
                case 15:
                    PicName = Memory_Game.Properties.Resources.p15;
                    break;
                case 16:
                    PicName = Memory_Game.Properties.Resources.p16;
                    break;
                case 17:
                    PicName = Memory_Game.Properties.Resources.p17;
                    break;
                case 18:
                    PicName = Memory_Game.Properties.Resources.p18;
                    break;
                case 19:
                    PicName = Memory_Game.Properties.Resources.p19;
                    break;
                case 20:
                    PicName = Memory_Game.Properties.Resources.p20;
                    break;
            }
            return (PicName);
        }

        private void Pic00_Click(object sender, EventArgs e)
        {
            PictureBox objSender = (PictureBox)sender;
            Play(objSender);
        }

        private void PlayCheck()
        {
            if (PlayerChoosenPic[0] == PlayerChoosenPic[1])
            {
                if (Player == true)
                {
                    Score1 += 10;
                    lblscore1.Text = Score1.ToString();
                }
                else
                {
                    Score2 += 10;
                    lblscore2.Text = Score2.ToString();
                }
                if (Score1 + Score2 == 80)
                {
                    ShowWinner();
                }
                timer2.Enabled = true;

              //  MoveWinningCard(PlayerChoosenPic[0]);
            }
            else
            {
                if (Player == true)
                {
                    Player = false;
                    lblPlayer.Text = Player2 + "'s Turn";
                    
                }
                else
                {
                    Player = true;
                    lblPlayer.Text = "Player 1's Turn";
                }
                timer1.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            PicBox1.Image = Memory_Game.Properties.Resources.Right;
            PicBox1.Enabled = false;
            PicBox2.Image = Memory_Game.Properties.Resources.Right;
            PicBox2.Enabled = false;
            if (Player2 == "PC" && Player==false)
            {
                timer3.Enabled = true;
            }
            timer2.Enabled = false;
        }

        private void ShowWinner()
        {
            if (Score1 > Score2)
            {
                lblPlayer.Text = "Player 1 Wins";
            }
            else if (Score2 > Score1)
            {
                lblPlayer.Text = Player2 + " Wins";
                
            }
            else
            {
                lblPlayer.Text = "Draw!!!";
            }
            DrawWinner(lblPlayer.Text);
            GameEnd = true;
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;

        }

        private void DrawWinner(string Winner)
        {lblWin.Left = 120;
            lblWin.Top = 190;
            lblWin.Text = Winner;
            lblWin.Show();

            Pic12.Hide();
            Pic22.Hide();
            Pic21.Hide();
            Pic11.Hide();
        }

        private void Play(PictureBox sender)
        {
            if (Turn == true)
            {
                PicBox1 = sender;
                Animate(PicBox1);
                PicBox1.Enabled = false;
                PicBox1.Image = ShowChoosenPic(Convert.ToInt32(PicBox1.Name[3].ToString()),
                    Convert.ToInt32(PicBox1.Name[4].ToString()));
                Turn = false;
                PlayerChoosenPic[0] = BoxRnd[Convert.ToInt32(PicBox1.Name[3].ToString()),
                    Convert.ToInt32(PicBox1.Name[4].ToString())];
                Animate(PicBox1);
            }
            else
            {
                PicBox2 = sender;
                Animate(PicBox2);
                PicBox2.Enabled = false;
                PicBox2.Image = ShowChoosenPic(Convert.ToInt32(PicBox2.Name[3].ToString()),
                    Convert.ToInt32(PicBox2.Name[4].ToString()));
                PlayerChoosenPic[1] = BoxRnd[Convert.ToInt32(PicBox2.Name[3].ToString()),
                Convert.ToInt32(PicBox2.Name[4].ToString())];

                Turn = true;
                PlayCheck();
                Animate(PicBox2);
            }
        }

        private void PCPlay()
        {
            switch (PCDifficult)
            {
                case 0:
                    PCEasyPlay();
                    break;
                case 1:
                    PCMediumHardPlay(4);
                    break;
                case 2:
                    PCMediumHardPlay(2);
                    break;
                
            }
        }

        private PictureBox WhichBox(int x, int y)
        {
            PictureBox PicBox = null;

            switch (x)
            {
                case 0:
                    switch (y)
                    {
                        case 0:
                            PicBox = Pic00;
                            break;
                        case 1:
                            PicBox = Pic01;
                            break;
                        case 2:
                            PicBox = Pic02;
                            break;
                        case 3:
                            PicBox = Pic03;
                            break;

                    }
                    break;
                case 1:
                    switch (y)
                    {
                        case 0:
                            PicBox = Pic10;
                            break;
                        case 1:
                            PicBox = Pic11;
                            break;
                        case 2:
                            PicBox = Pic12;
                            break;
                        case 3:
                            PicBox = Pic13;
                            break;

                    }
                    break;
                case 2:
                    switch (y)
                    {
                        case 0:
                            PicBox = Pic20;
                            break;
                        case 1:
                            PicBox = Pic21;
                            break;
                        case 2:
                            PicBox = Pic22;
                            break;
                        case 3:
                            PicBox = Pic23;
                            break;

                    }
                    break;
                case 3:
                    switch (y)
                    {
                        case 0:
                            PicBox = Pic30;
                            break;
                        case 1:
                            PicBox = Pic31;
                            break;
                        case 2:
                            PicBox = Pic32;
                            break;
                        case 3:
                            PicBox = Pic33;
                            break;

                    }
                    break;
            }
            return (PicBox);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            PCPlay();
            timer3.Enabled = false;
        }

        private void Animate(PictureBox PicBox11)
        {
            if (PicBox11.Width != 0)
            {
                for (int i = PicBox11.Width; i >= 0; i--)
                {
                    PicBox11.Width -= 2;
                    PicBox11.Left += 1;
                    for (int j = 0; j <= 500000; j++)
                    {
                    }
                }
            }
            else
            {
                for (int i = 0; i < 65; i++)
                {
                    PicBox11.Width += 1;
                    PicBox11.Left -= 1;
                    for (int j = 0; j <= 500000; j++)
                    {


                    }
                }
                PicBox11.Left -= 1;
            }

            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Show >>")
            {
                this.Width += 200;
                button3.Text = "<< Hide";
                button3.Left += 200;
                button1.Left += 200;
                button2.Left += 200;
            }
            else
            {
                this.Width -= 200;
                button3.Text = "Show >>";
                button3.Left -= 200;
                button1.Left -= 200;
                button2.Left -= 200;
            }
        }

        private void VsPC_CheckedChanged(object sender, EventArgs e)
        {
            VsPCGroup.Enabled = VsPC.Checked;
        }

        private void VsPlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (VsPlayer.Checked == true)
            {
                PicPlayMode.Image = Memory_Game.Properties.Resources.Person;
                //PlayVsPC = false;
                this.Text = "Memory Game (Vs. Player 2)";
                Player2 = "Player 2";
            }
            else
            {
                PicPlayMode.Image = Memory_Game.Properties.Resources.PC;
                //PlayVsPC = true;
                this.Text = "Memory Game (Vs. Computer)";
                Player2 = "PC";
                PCDifficult = 0;
                EasyCheck.Checked = true;
            }
        }

        private void Check()
        {
            if (EasyCheck.Checked == true)
                PCDifficult = 0;
            else if (MediumCheck.Checked == true)
                PCDifficult = 1;
            else
                PCDifficult = 2;
        }

        private void MediumCheck_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void EasyCheck_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void PCEasyPlay()
        {
            if (GameEnd == true)
                return;
            int[] x = new int[2];
            PictureBox PicBox = null;
            aii = false;
            while (aii == false)
            {
                x[0] = Rnd.Next(0, 4);
                x[1] = Rnd.Next(0, 4);

                PicBox = WhichBox(x[0], x[1]);
                if (PicBox.Enabled == true)
                {
                    aii = true;
                    Play(PicBox);
                }
            }
            bii = false;
            while (bii == false)
            {
                x[0] = Rnd.Next(0, 4);
                x[1] = Rnd.Next(0, 4);

                PicBox = WhichBox(x[0], x[1]);
                if (PicBox.Enabled == true)
                {
                    bii = true;
                    Play(PicBox);
                }
            }
        }

        private void VsPCGroup_Enter(object sender, EventArgs e)
        {

        }

        private void HardCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblWin_Click(object sender, EventArgs e)
        {

        }

        private void lblPlayer_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblscore1_Click(object sender, EventArgs e)
        {

        }

        private void lblscore2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PCMediumHardPlay(int Deff)
        {
            if (GameEnd == true)
                return;
            int[] x = new int[2];
            int PcRndYesNo = 0, i = 0, j = 0;
            

            PcRndYesNo = Rnd.Next(1, Deff);
            if (PcRndYesNo == 1)
            {
                i = 0;
                PictureBox PicBox5 = null, PicBox6 = null;
                aii = false;
                bii = false;
                while (aii == false || bii == false)
                {
                    x[0] = WinningCards[i, 0];
                    x[1] = WinningCards[i, 1];

                    PicBox5 = WhichBox(x[0], x[1]);
                    if (PicBox5.Enabled == true)
                    {
                        aii = true;
                    }
                
                    x[0] = WinningCards[i, 2];
                    x[1] = WinningCards[i, 3];

                    PicBox6 = WhichBox(x[0], x[1]);
                    if (PicBox6.Enabled == true)
                    {
                        bii = true;
                    }
                    i++;
                }

                Play(PicBox5);
                Play(PicBox6);
                
            }
            else
            {
                i = 0;
                aii = false;
                PictureBox PicBox5 = null;
                while (aii == false)
                {
                    x[0] = Rnd.Next(0, 4);
                    x[1] = Rnd.Next(0, 4);

                    PicBox5 = WhichBox(x[0], x[1]);
                    if (PicBox5.Enabled == true)
                    {
                        aii = true;
                        Play(PicBox5);
                    }
                }
                bii = false;
                while (bii == false)
                {
                    x[0] = Rnd.Next(0, 4);
                    x[1] = Rnd.Next(0, 4);

                    PicBox5 = WhichBox(x[0], x[1]);
                    if (PicBox5.Enabled == true)
                    {
                        bii = true;
                        Play(PicBox5);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/milad_sarhadbani");
        }

       /* private void MoveWinningCard(int a)
        {
            string Card;
            int First = 0, Sec = 0;

            Card = a.ToString();

            First = Convert.ToInt32(Card[0].ToString());
            Sec = Convert.ToInt32(Card[1].ToString());


        }*/

    }
}
