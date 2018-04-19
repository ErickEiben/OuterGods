using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterGods.Cards 
{
    public class SiblingIndexer : MonoBehaviour 
    {
        private void Awake()
        {
            switch (name)
            {
                case "CardName":
                    transform.SetSiblingIndex(0);
                    break;
                case "CardDescription":
                    transform.SetSiblingIndex(1);
                    break;
                case "SanityCost":
                    transform.SetSiblingIndex(2);
                    break;
                case "StaminaCost":
                    transform.SetSiblingIndex(3);
                    break;
            }
        }
    }
}
