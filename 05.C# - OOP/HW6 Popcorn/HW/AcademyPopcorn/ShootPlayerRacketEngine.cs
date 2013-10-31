//Task04
//Inherit the Engine class. Create a method ShootPlayerRacket. Leave it empty for now.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    //------
    //Task04
    //------
    public class ShootPlayerRacketEngine : Engine
    {
        public void ShootPlayerRacket() 
        {
            if (this.playerRacket is ShootingRacket)
            {
                ShootingRacket currentPlayerRacket = this.playerRacket as ShootingRacket;
                currentPlayerRacket.Shoot = true;
            }
        }

        public virtual void DoRacketAction()
        {
            this.ShootPlayerRacket();
        }

        public ShootPlayerRacketEngine(IRenderer renderer, IUserInterface userInterface, int pSleepTime)
            : base(renderer, userInterface, pSleepTime)
        { }
    }
}
