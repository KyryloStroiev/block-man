using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input.Behaviours
{
    public class InputJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public RectTransform target;
        public RectTransform touchpadArea;
        public float sensitivity;
        
        private Vector2 lastPointerPosition;

        private void Update()
        {
         Debug.Log(lastPointerPosition);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    touchpadArea,
                    eventData.position,
                    eventData.pressEventCamera,
                    out lastPointerPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(!RectTransformUtility.RectangleContainsScreenPoint(target, eventData.position, eventData.pressEventCamera))
                return;
            
            Vector2 currentPointerPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                touchpadArea,
                eventData.position,
                eventData.pressEventCamera,
                out currentPointerPosition);
            Vector2 delta = currentPointerPosition - lastPointerPosition;
            lastPointerPosition = currentPointerPosition;
            
            Vector2 newPosition = target.anchoredPosition + delta * sensitivity;

            Vector2 canvasSize = touchpadArea.rect.size * 0.5f;
            newPosition.x = Mathf.Clamp(newPosition.x, -canvasSize.x, canvasSize.x);
            newPosition.y = Mathf.Clamp(newPosition.y, -canvasSize.y, canvasSize.y);
            
            target.anchoredPosition = newPosition;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            target.anchoredPosition = Vector2.zero;
        }
    }
}