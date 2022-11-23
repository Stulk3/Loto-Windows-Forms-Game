using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto
{
    public class Card
    {
        private int[,] numbers;
        private int remainingNumbersCount = 15;
        private bool isCleared = false;
        public List<int> remainingNumbers = new List<int>();

        public Card() : base()
        {
            numbers = new int[3,9] {
                {1,0,1,1,0,1,0,1,0},
                {0,0,1,0,1,1,1,1,0},
                {0,1,0,1,1,0,1,1,0}, 
            };
            FillCardWithNumbers();
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
            for(int i = 0; i < 9; i++)
            {
                if (numbers[rowNumber, i] == 1)
                {
                    int number = LottoMaster.instance.GetNumberFromCardPool();
                    SetNumber(rowNumber, i, number);
                    remainingNumbers.Add(number);
                }
            }
        }
        public bool IsCleared()
        {
            return isCleared;
        }
        public void CheckForCardCleared()
        {
            if (remainingNumbers.Count == 0)
            {
                isCleared = true;
            }
        }
        public List<int> GetRemainingNumbersList()
        {
            return remainingNumbers;
        }
        public int[,] GetNumbersArray()
        {
            return numbers;
        }
        public void SetNumbersArray(int[,] array)
        {
            numbers = array;
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
