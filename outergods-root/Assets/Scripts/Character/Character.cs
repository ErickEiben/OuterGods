using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OuterGods.Characters
{
    public abstract class Character : MonoBehaviour
    {
        public string characterName = "Nameless";
        public int health = 10;

        protected virtual void Start()
        {

        }
    }
}
