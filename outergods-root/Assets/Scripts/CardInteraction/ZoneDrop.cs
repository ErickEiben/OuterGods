using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

namespace OuterGods.CardInteraction
{
    public class ZoneDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        #region OnPointerEnter
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) { return; }

            var draggableCard = eventData.pointerDrag.GetComponent<Draggable>();

            if (draggableCard != null)
            {
                draggableCard.cardPlaceholderParent = transform;
            }
        }
        #endregion

        #region OnPointerExit
        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) { return; }

            var draggableCard = eventData.pointerDrag.GetComponent<Draggable>();

            if (draggableCard != null && draggableCard.cardPlaceholderParent == transform)
            {
                draggableCard.cardPlaceholderParent = draggableCard.parentToReturnTo;
            }
        }
        #endregion

        #region OnDrop
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) { return; }

            var draggableCard = eventData.pointerDrag.GetComponent<Draggable>();

            if (tag == "DropZone")
            {
                if (draggableCard != null)
                {
                    Destroy(draggableCard.gameObject);
                }
            }

            else if (tag == "PlayerHand")
            {
                if (draggableCard != null)
                {
                    draggableCard.parentToReturnTo = transform;
                }
            }
        }
        #endregion
    }
}
