using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject canvasObject;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Vector3 originalPos;
    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
    }
    void Start(){
        canvasObject = GameObject.FindWithTag("canvas");
        canvas = canvasObject.GetComponent<Canvas>();
        
    }
    public void OnBeginDrag(PointerEventData eventData){
        originalPos = transform.position;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        transform.position = originalPos;
    }


    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    /// On Item Click Events
    public void OnPointerClick(PointerEventData eventData){
        
        if (eventData.pointerDrag != null){
            Debug.Log("OnPointerDown");
            switch(eventData.pointerDrag.GetComponent<ItemUI>().item.type){
                case "stone":
                    {
                        /// For the buture
                        break;
                    }
                case "constructable":
                    {
                        eventData.pointerDrag.GetComponent<ConstructableItemUI>().action();
                        break;
                    }
            }
        }
    }

}
