using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class PlayerData
    {
        public static PlayerData instance;
        private int remainingNumbers = 30;
        
        public PlayerData(): base()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void MarkOutNumber()
        {
            remainingNumbers -= 1;
        }

    }
}
