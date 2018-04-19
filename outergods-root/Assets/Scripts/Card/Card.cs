using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OuterGods.Cards
{
    public abstract class Card : MonoBehaviour
    {
        #region Variables
        protected int cardID;
        
        public string cardName = "Basic Card";
        public string cardDescription = "This is the basic card description.";
        public int sanityCost;
        public int staminaCost;
        
        protected Text cardNameText;
        protected Text cardDescriptionText;
        protected Text sanityCostText;
        protected Text staminaCostText;
        #endregion

        #region Abstract Functions
        public abstract void CardEffect();
        #endregion

        #region Start
        protected virtual void Start()
        {
            var cardTexts = GetComponentsInChildren<Text>();

            cardNameText = cardTexts[0];
            cardDescriptionText = cardTexts[1];
            sanityCostText = cardTexts[2];
            staminaCostText = cardTexts[3];

            gameObject.name = cardName;
            cardNameText.text = cardName;
            cardDescriptionText.text = cardDescription;
            sanityCostText.text = sanityCost.ToString();
            staminaCostText.text = staminaCost.ToString();
        }
        #endregion
    }
}
