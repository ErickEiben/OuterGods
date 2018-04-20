using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterGods.Cards
{
    public class CardData : ScriptableObject
    {
        #region Variables
        [Header("Name of the card")]
        public string cardName;

        [Header("Description of the card")]
        public string cardDescription;

        [Header("Sanity cost of the card")]
        public int sanityCost;

        [Header("Stamina cost of the card")]
        public int staminaCost;

        [Header("Icon that will be used on the card")]
        public Sprite icon;

        [SerializeField, Header("Prefab attached to this Scriptable Object")]
        private CardInstance cardPrefab;
        #endregion

        #region Properties
        public CardInstance CardPrefab
        {
            get
            {
                return cardPrefab;
            }
        }
        #endregion
    }
}
