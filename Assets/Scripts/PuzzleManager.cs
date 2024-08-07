using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class PuzzleManager : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void SetStart ();
    [SerializeField] private GameObject piece;
    [SerializeField] private GameObject socket;
    [SerializeField] private GameObject referenceImage;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private Sprite image;

    //url
    [SerializeField] private string url = "";
    [SerializeField] private bool useUrl = false;
    
    //loading trigger
    [SerializeField] private UnityEvent finishLoading;
    
    //for transitions specifically, can be removed if it makes diagrams too complex
    [SerializeField] private UnityEvent startLoading;
    [SerializeField] private GameObject transitionControl;
   
    //load in an image from a url
    //to load urls from other servers properly CORS has to be implemented
    // guides: https://www.youtube.com/watch?v=PNtFSVU-YTI
    // https://discussions.unity.com/t/load-url-images-in-webgl/149373

    private IEnumerator LoadCoroutine()
    {
        //transition code
        Time.timeScale = 0f;
        startLoading.Invoke();
        
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) 
        {
            Debug.Log(www.error);
        }
        else 
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Sprite imagedummy = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0, 0));
            image = imagedummy;
            Debug.Log("loaded!");
        }
        CreatePieces();
        //code for transition, remove if too complex
        
        //StartCoroutine(transitionControl.GetComponent<TransitionController>().ExpandCoroutine(this.transform.Find("Canvas")));
        //yield return new WaitForSecondsRealtime(0.8f);
        Time.timeScale = 1f;

    }
    // Start is called before the first frame update
    void Start()
    {
        //SetStart();

        if(useUrl)
        {
           StartCoroutine(LoadCoroutine());
        }
        else
        {
           CreatePieces();
        }

        print(Singleton.Instance.test);
    }
    
    //create the sockets and the pieces for the puzzle

    public void GetUrl(string newurl)
    {
       url = newurl;
    }

    void CreatePieces()
    {  
       referenceImage.GetComponent<Image>().sprite = image;
       int[,] puzzle9pc = {{48,-48},{0,-48},{-48,-48},{48,0},{0,0},{-48,0},{48,48},{0,48},{-48,48}};
       //wtf why did the .Length also include the size of the mini arrays??? this is bullshit
       
       //spawn sockets
       for (int i = 0; i < puzzle9pc.Length/2; i++)
       {
          GameObject puzzlesocket = Instantiate(socket, canvas);
          
          puzzlesocket.GetComponent<RectTransform>().anchoredPosition = new Vector2(puzzle9pc[i,0]-100,puzzle9pc[i,1]);
          puzzlesocket.GetComponent<RectTransform>().localPosition = new Vector3(puzzle9pc[puzzle9pc.Length/2-1-i,0]-100,puzzle9pc[puzzle9pc.Length/2-1-i,1],0);
          puzzlesocket.GetComponent<Socket>().slotno = "A" + i.ToString();

       }
      
       //spawn puzzle pieces
       for (int i = 0; i < puzzle9pc.Length/2; i++)
       {
          GameObject puzzlepc = Instantiate(piece, canvas);
          
          puzzlepc.transform.GetChild(0).GetComponent<Image>().sprite = image;
          puzzlepc.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(puzzle9pc[i,0],puzzle9pc[i,1]);
          
          //old code to spawn puzzle pieces uniformly
          //puzzlepc.GetComponent<RectTransform>().anchoredPosition = new Vector2(puzzle9pc[i,0]+100,puzzle9pc[i,1]);
          //puzzlepc.GetComponent<RectTransform>().localPosition = new Vector3(puzzle9pc[puzzle9pc.Length/2-1-i,0]+100,puzzle9pc[puzzle9pc.Length/2-1-i,1], 1);
          
          //this spawns them randomly
          puzzlepc.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-50.0f,50.0f)+100,Random.Range(-50.0f,50.0f));
          puzzlepc.GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(-50.0f,50.0f)+100,Random.Range(-50.0f,50.0f), 1);

          puzzlepc.GetComponent<Piece>().slotno = "A" + i.ToString();

       }

       finishLoading.Invoke();
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
