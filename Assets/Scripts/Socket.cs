using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Socket : MonoBehaviour, IDropHandler
{
    public string slotno = "test";
    public GameObject audioPlayer;

    [Header("Events")]
    public GameEvent pieceSlot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if ((eventData.pointerDrag != null) && (eventData.pointerDrag.GetComponent<Piece>().slotno == slotno))
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<Piece>().slotted = true;
            Instantiate(audioPlayer).GetComponent<AudioController>().slotPuzzle();
            pieceSlot.Raise();
        }
    }
}
