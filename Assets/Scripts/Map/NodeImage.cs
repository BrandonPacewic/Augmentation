using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Map
{
    public class NodeImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData data)
        {
            Debug.Log("OnPointerEnter");
        }

        public void OnPointerExit(PointerEventData data)
        {
            Debug.Log("OnPointerExit");
        }

        public void OnMouseDown()
        {
            Debug.Log("OnMouseDown");
        }

        public void OnMouseUp()
        {
            Debug.Log("OnMouseUp");
        }
    }
}
