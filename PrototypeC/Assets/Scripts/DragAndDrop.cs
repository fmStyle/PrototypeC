using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
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
        Debug.Log("OnPointerDown");
        canvasGroup.blocksRaycasts = true;
        transform.position = originalPos;
        canvasGroup.alpha = 1.0f;
    }


    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }
}
