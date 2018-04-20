using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OuterGods.Cards
{
    public class CardInstance : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        protected CardData cardID;

        protected Text cardNameText;
        protected Text cardDescriptionText;
        protected Text sanityCostText;
        protected Text staminaCostText;
        #endregion

        #region Start
        protected virtual void Start()
        {
            var cardTexts = GetComponentsInChildren<Text>();

            cardNameText = cardTexts[0];
            cardDescriptionText = cardTexts[1];
            sanityCostText = cardTexts[2];
            staminaCostText = cardTexts[3];

            if (cardID != null)
            {
                cardNameText.text = cardID.cardName;
                cardDescriptionText.text = cardID.cardDescription;
                sanityCostText.text = cardID.sanityCost.ToString();
                staminaCostText.text = cardID.staminaCost.ToString();
            }
        }
        #endregion
    }
}
