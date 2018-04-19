using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterGods.Cards 
{
    public class Shotgun : PhysicalCard
    {
        #region Variables
        private int damageMin = 3;
        private int damageMax = 5;
        #endregion

        #region Start
        protected override void Start()
        {
            cardID = 1000;
            cardName = "Shotgun";
            cardDescription = ("Deal " + damageMin + " - " + damageMax + " damage.");
            sanityCost = 0;
            staminaCost = 2;
            base.Start();
        }
        #endregion

        #region CardEffect
        public override void CardEffect()
        {

        }
        #endregion
    }
}
