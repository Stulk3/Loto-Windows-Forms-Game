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
        private int remainingNumbers = 15;
        private bool isCleared = false;

        public Card() : base()
        {
            numbers = new int[3,9] {
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0}, 
            };
        }
        public int GetRemainingNumbers()
        {
            return remainingNumbers;
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
            remainingNumbers -= 1;
            CheckForCardCleared();
        }
        private void CheckForCardCleared()
        {
            if(remainingNumbers == 0)
            {
                isCleared = true;
            }
        }
    }
}
