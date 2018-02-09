using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace CardManager
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform parentToReturnTo = null; // Parent drop zone which the card will return to on EndDrag
        public Transform placeholderParent = null;

        GameObject placeholder = null;

        public void OnBeginDrag(PointerEventData eventData)
        {
            placeholder = new GameObject();
            placeholder.transform.SetParent(transform.parent); // Sets the parent of the placeholder to the parent of this gameobject, e.g. the drop zone this gameobject is in
            // Adds a LayoutElement to the placeholder
            LayoutElement le = placeholder.AddComponent<LayoutElement>();
            le.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
            le.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
            le.flexibleHeight = 0;
            le.flexibleWidth = 0;

            placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

            parentToReturnTo = transform.parent;
            placeholderParent = parentToReturnTo;
            transform.SetParent(transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;

            if(placeholder.transform.parent != placeholderParent)
            {
                placeholder.transform.SetParent(placeholderParent);
            }

            // Determines if the card being held is moving down the layout, if so move the placeholder to the new position
            int newSiblingIndex = placeholderParent.childCount;

            for(int i=0; i < placeholderParent.childCount; i++)
            {
                if (transform.position.x < placeholderParent.GetChild(i).position.x)
                {
                    newSiblingIndex = i;

                    if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    {
                        newSiblingIndex--;
                    }

                    break;
                }
            }

            placeholder.transform.SetSiblingIndex(newSiblingIndex);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(parentToReturnTo);
            transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Destroy(placeholder);
        }
    }
}

