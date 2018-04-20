using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace OuterGods.CardInteraction
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region Variables
        [HideInInspector]
        public Transform parentToReturnTo; // Parent drop zone which the card will return to on EndDrag

        [HideInInspector]
        public Transform cardPlaceholderParent;

        private GameObject cardPlaceholder;
        #endregion

        #region OnBeginDrag
        public void OnBeginDrag(PointerEventData eventData)
        {
            cardPlaceholder = new GameObject();
            cardPlaceholder.transform.SetParent(transform.parent); // Sets the parent of the placeholder to the parent of this gameobject, e.g. the drop zone this gameobject is in
            // Adds a LayoutElement to the placeholder
            var cardLayoutElement = cardPlaceholder.AddComponent<LayoutElement>();
            cardLayoutElement.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
            cardLayoutElement.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
            cardLayoutElement.flexibleHeight = 0;
            cardLayoutElement.flexibleWidth = 0;

            cardPlaceholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

            parentToReturnTo = transform.parent;
            cardPlaceholderParent = parentToReturnTo;
            transform.SetParent(transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        #endregion

        #region OnDrag
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;

            if (cardPlaceholder.transform.parent != cardPlaceholderParent)
            {
                cardPlaceholder.transform.SetParent(cardPlaceholderParent);
            }

            int newSiblingIndex = cardPlaceholderParent.childCount;

            for (int i = 0; i < cardPlaceholderParent.childCount; i++)
            {
                if (transform.position.x < cardPlaceholderParent.GetChild(i).position.x)
                {
                    newSiblingIndex = i;

                    if (cardPlaceholder.transform.GetSiblingIndex() < newSiblingIndex)
                    {
                        newSiblingIndex--;
                    }

                    break;
                }
            }
            cardPlaceholder.transform.SetSiblingIndex(newSiblingIndex);
            // Determines if the card being held is moving down the layout, if so move the placeholder to the new position
        }
        #endregion

        #region OnEndDrag
        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(parentToReturnTo);
            transform.SetSiblingIndex(cardPlaceholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Destroy(cardPlaceholder);
        }
        #endregion
    }
}
