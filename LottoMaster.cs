using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto
{
    class LottoMaster
    {
        public static LottoMaster instance;

        public bool isPlayerWon = false;

        private List<int> gameNumbersPool = new List<int>{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,
        31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,
        61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90};


        private List<int> cardNumbersPool = new List<int>{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,
        31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,
        61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90};

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
        public List<int> GetGameNumberPool()
        {
            return gameNumbersPool;
        }
        public void ShufflePool(List<int> pool)
        {
            pool.Shuffle();
        }

        public int GetNumberFromGamePool()
        {
            if (gameNumbersPool.Any() && gameNumbersPool.Count > 0)
            {
                int number = 0;
                number = gameNumbersPool.Last();
                gameNumbersPool.Remove(number);
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
                cardNumbersPool.Remove(number);
                return number;
            }
            return 0;
        }
        public void CheckForPlayerCardsCleared(Card card1, Card card2)
        {
            card1.CheckForCardCleared();
            card2.CheckForCardCleared();
            if(card1.IsCleared() & card2.IsCleared())
            {
                isPlayerWon = true;
                EndGame();
            }
        }
        public void CheckForComputerCardsCleared(Card card1, Card card2)
        {
            card1.CheckForCardCleared();
            card2.CheckForCardCleared();
            if (card1.IsCleared() & card2.IsCleared())
            {
                isPlayerWon = false;
                EndGame();
            }
        }
        public void EndGame()
        {
            gameEnded = true;
        }

    }
}
