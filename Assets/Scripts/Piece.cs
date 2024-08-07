using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Piece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public bool slotted =  false;
    public string slotno = "test";
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
    [SerializeField] private UnityEvent playSound;
    [SerializeField] private GameObject audioPlayer;
    
    void Update()
    {
        
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //it has to grab from the parent so that drag/drop works properly but it kinda sucks though
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(audioPlayer).GetComponent<AudioController>().pickPuzzle();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();

        if(slotted == false)
        {
           canvasGroup.alpha = .6f;
           canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       canvasGroup.alpha = 1f;
       canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(slotted == false)
        {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
       
    }

    void Start()
    {

    }
}
