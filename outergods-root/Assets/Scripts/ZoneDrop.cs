using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace CardManager
{
    public class ZoneDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            if(eventData.pointerDrag == null)
            {
                return;
            }

            var draggable = eventData.pointerDrag.GetComponent<Draggable>();
            if(draggable != null)
            {
                draggable.placeholderParent = transform;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
            {
                return;
            }

            var draggable = eventData.pointerDrag.GetComponent<Draggable>();
            if (draggable != null && draggable.placeholderParent == transform)
            {
                draggable.placeholderParent = draggable.parentToReturnTo;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            var draggable = eventData.pointerDrag.GetComponent<Draggable>();
            if(draggable != null)
            {
                draggable.parentToReturnTo = transform;
            }
        }
    }
}

