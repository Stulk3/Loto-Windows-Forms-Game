using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Lotto;

namespace Lotto
{
    public partial class Lotto : Form
    {
        private Label[,] card1Labels;
        private Label[,] card2Labels;

        private LottoMaster lottoMaster = new LottoMaster();
        private PlayerData playerData = new PlayerData();

        private Card playerCard1= new Card();
        private Card playerCard2 = new Card();

        public int[,] test = new int[3,9];
        //private Card computerCard1 = new Card();
        //private Card computerCard2 = new Card();


        private int numberFromPool;

        private int labelRowIndex;
        private int labelColumnIndex;
        public Lotto()
        {
            InitializeComponent();
        }

        private void Loto_Load(object sender, EventArgs e)
        {
            card1Labels = new Label[3, 9] {
                {t11,t12,t13,t14,t15,t16,t17,t18,t19},
                {t21,t22,t23,t24,t25,t26,t27,t28,t29},
                {t31,t32,t33,t34,t35,t36,t37,t38,t39},
            };
            card2Labels = new Label[3, 9] {
                {d11,d12,d13,d14,d15,d16,d17,d18,d19},
                {d21,d22,d23,d24,d25,d26,d27,d28,d29},
                {d31,d32,d33,d34,d35,d36,d37,d38,d39},
            };
            UpdateUI();
        }
        private void UpdateUI()
        {
            UpdateCard1UI();
            UpdateCard2UI();
        }
        private void UpdateCard1UI()
        {
            int[,] card1numbers = playerCard1.GetNumbersArray();

            for(int i = 0; i < 9; i++)
            {
                if(card1numbers[0, i] != 0)
                card1Labels[0, i].Text = card1numbers[0, i].ToString();
            }

            for (int i = 0; i < 9; i++)
            {
                if (card1numbers[1, i] != 0)
                    card1Labels[1, i].Text = card1numbers[1, i].ToString();
            }

            for (int i = 0; i < 9; i++)
            {
                if (card1numbers[2, i] != 0)
                    card1Labels[2, i].Text = card1numbers[2, i].ToString();
            }
        }
        private void UpdateCard2UI()
        {
            int[,] card2numbers = playerCard2.GetNumbersArray();

            for (int i = 0; i < 9; i++)
            {
                if (card2numbers[0, i] != 0)
                    card2Labels[0, i].Text = card2numbers[0, i].ToString();
            }

            for (int i = 0; i < 9; i++)
            {
                if (card2numbers[1, i] != 0)
                    card2Labels[1, i].Text = card2numbers[1, i].ToString();
            }

            for (int i = 0; i < 9; i++)
            {
                if (card2numbers[2, i] != 0)
                    card2Labels[2, i].Text = card2numbers[2, i].ToString();
            }
        }
        private int[] FillRow(int number,int[,] array, int rowNumber)
        {
            int[] outputArray = new int[9];
            for (int i = 0; i < 9; i++)
            {
                outputArray[i] = array[rowNumber, i];                
            }
            return outputArray;
        }
        public void CheckForNumberFromPool(int number, Card card1, Card card2)
        {

            List<int> cardList1 = card1.GetRemainingNumbersList();
            List<int> cardList2 = card2.GetRemainingNumbersList();

            int[,] card1NumbersArray = new int[3, 9];
            int[,] card2NumbersArray = new int[3, 9];

            card1NumbersArray = card1.GetNumbersArray();
            card2NumbersArray = card2.GetNumbersArray();
            int[] numbersRow1;
            int[] numbersRow2;
            int[] numbersRow3;

            bool isExistInCard1 = cardList1.Contains(number);
            bool isExistInCard2 = cardList2.Contains(number);
            if (isExistInCard1)
            {
                numbersRow1 = FillRow(number, card1NumbersArray, 0);
                for (int i = 0; i < 9; i++)
                {
                    if(numbersRow1[i] == number)
                    {
                        CrossOutNumber(0, i, card1Labels);
                        playerCard1.remainingNumbers.Remove(number);
                    }
                }
                numbersRow2 = FillRow(number, card1NumbersArray, 1);
                for (int i = 0; i < 9; i++)
                {
                    if (numbersRow2[i] == number)
                    {
                        CrossOutNumber(1, i, card1Labels);
                        playerCard1.remainingNumbers.Remove(number);
                    }
                }
                numbersRow3 = FillRow(number, card1NumbersArray, 1);
                for (int i = 0; i < 9; i++)
                {
                    if (numbersRow3[i] == number)
                    {
                        CrossOutNumber(2, i, card1Labels);
                        playerCard1.remainingNumbers.Remove(number);
                    }
                }

               
                //UpdateCard1UI();

            }
            if (isExistInCard2)
            {
                numbersRow1 = FillRow(number, card2NumbersArray, 0);
                for (int i = 0; i < 9; i++)
                {
                    if (numbersRow1[i] == number)
                    {
                        CrossOutNumber(0, i, card2Labels);
                        playerCard2.remainingNumbers.Remove(number);
                    }
                }
                numbersRow2 = FillRow(number, card2NumbersArray, 1);
                for (int i = 0; i < 9; i++)
                {
                    if (numbersRow2[i] == number)
                    {
                        CrossOutNumber(1, i, card2Labels);
                        playerCard2.remainingNumbers.Remove(number);
                    }
                }
                numbersRow3 = FillRow(number, card2NumbersArray, 1);
                for (int i = 0; i < 9; i++)
                {
                    if (numbersRow3[i] == number)
                    {
                        CrossOutNumber(2, i, card2Labels);
                        playerCard2.remainingNumbers.Remove(number);
                    }
                }
            }
            Console.WriteLine("Оставшиеся номера");
            Console.WriteLine(playerCard1.GetRemainingNumbersList().Count);
            Console.WriteLine(playerCard2.GetRemainingNumbersList().Count);

            Console.WriteLine("Осталось бочек");
            Console.WriteLine(lottoMaster.GetGameNumberPool().Count);
        }
        public void CrossOutNumber(int x, int y, Label[,] labels)
        {
            labels[x, y].Text = "X";
        }
        public void EndGame()
        {
            if (lottoMaster.isPlayerWon)
            {
                MessageBox.Show("Вы победили!", "Победа", MessageBoxButtons.OK);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Вы проиграли!", "Поражение", MessageBoxButtons.OK);
                Application.Exit();
            }
        }
        private void NextNumberButton_Click(object sender, EventArgs e)
        {
            numberFromPool = lottoMaster.GetNumberFromGamePool();
            CheckForNumberFromPool(numberFromPool, playerCard1, playerCard2);
            //CheckForNumberFromPool(numberFromPool, computerCard1, computerCard2);
            lottoMaster.CheckForCardsCleared(playerCard1, playerCard2);
            if (lottoMaster.GameEnded())
            {
                EndGame();
            }
        }

        private void buttonEndGame_Click(object sender, EventArgs e)
        {
            EndGame();
        }
    }
}
