using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Card
    {
        private int[,] numbers;
        private int remainingNumbersCount = 15;
        private bool isCleared = false;
        private List<int> remainingNumbers = new List<int>();

        public Card() : base()
        {
            numbers = new int[3,9] {
                {1,0,1,1,0,1,0,1,0},
                {0,0,1,0,1,1,1,1,0},
                {0,1,0,1,1,0,1,1,0}, 
            };
            FillCardWithNumbers();
        }
        private void CheckForCardCleared()
        {
            if (remainingNumbersCount == 0)
            {
                isCleared = true;
            }
        }
        private void FillCardWithNumbers()
        {
            FillRow(0);
            FillRow(1);
            FillRow(2);
            Console.WriteLine(remainingNumbers.Last());
        }
        private void FillRow(int rowNumber)
        {
            for(int i = 0; i < 8; i++)
            {
                if (numbers[rowNumber, i] == 1)
                {
                    int number = LottoMaster.instance.GetNumberFromCardPool();
                    numbers[rowNumber, i] = number;
                    remainingNumbers.Add(number);
                }
            }
        }
        public int GetRemainingNumbers()
        {
            return remainingNumbersCount;
        }
        public int[,] GetNumbersArray()
        {
            return numbers;
        }
        public void SetNumber(int x, int y, int number)
        {
            numbers[x, y] = number;
        }
        public void MarkOutNumber(int x, int y)
        {
            numbers[x, y] = 0;
            remainingNumbersCount -= 1;
            CheckForCardCleared();
        }

    }
}
