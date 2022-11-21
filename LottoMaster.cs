using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class LottoMaster
    {
        public static LottoMaster instance;


        private List<int> gameNumbersPool = new List<int>{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,
        31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,
        61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90};
        private int gameNumberIndex = 89;


        private List<int> cardNumbersPool = new List<int>{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,
        31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,
        61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90};
        private int cardNumberIndex = 89;

        private bool gameEnded = false;
       
        public LottoMaster() : base()
        {
            if (instance == null)
            {
                instance = this;
            }
            ShufflePool(cardNumbersPool);
            ShufflePool(gameNumbersPool);
        }
        public bool GameEnded()
        {
            return gameEnded;
        }
        public void ShufflePool(List<int> pool)
        {
            pool.Shuffle();
        }

        public int GetNumberFromGamePool()
        {
            if (gameNumbersPool.Any() && gameNumberIndex >= 0)
            {
                int number = 0;
                number = gameNumbersPool.Last();
                gameNumbersPool.RemoveAt(gameNumberIndex);
                gameNumberIndex = gameNumberIndex - 1;
                return number;
            }
            return 0;
        }
        public int GetNumberFromCardPool()
        {
            if (cardNumbersPool.Any())
            {
                int number;
                number = cardNumbersPool.Last();
                cardNumbersPool.RemoveAt(cardNumberIndex);
                cardNumberIndex -= 1;
                return number;
            }
            return 0;
        }
        public int GetGameNumberIndex()
        {
            return gameNumberIndex;
        }
        public void CheckForCardsCleared(Card card1, Card card2)
        {
            card1.CheckForCardCleared();
            card2.CheckForCardCleared();
            if(card1.IsCleared() & card2.IsCleared())
            {
                EndGame();
            }
        }
        public void EndGame()
        {
            gameEnded = true;
        }

    }
}
