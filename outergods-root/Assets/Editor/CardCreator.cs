using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CardManager
{
    public class CardCreator : EditorWindow
    {
        [MenuItem("Outer Gods/Card Creator")]

        public static void ShowWindow() // Opens the window when clicked
        {
            EditorWindow.GetWindow(typeof(CardCreator), true, "Card Creator");
        }
        private void OnGUI()
        {
            
        }
    }
}


