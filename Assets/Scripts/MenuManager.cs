using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.InteropServices;

public class MenuManager : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void EnterMain ();
    [SerializeField] private GameObject audioPlayer;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private TMP_Text textcomponent;
    [SerializeField] private string username;
    
    //for transitions specifically, can be removed if it makes diagrams too complex
    [SerializeField] private GameObject transitionControl;

    [Header("Events")]
    public GameEvent shrinkTransition;
    
    // Start is called before the first frame update
    void Start()
    {
        //EnterMain();
        print(Singleton.Instance.test);
        Singleton.Instance.test = "static";
        //set username
        textcomponent.SetText("Welcome " + username + "!");
        //load in saved options
        optionsUI.SetActive(true);
        optionsUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
       
    }

    public void GetUsername(string newuser)
    {
       username = newuser;
    }
    
    //button code
    public void startClicked()
    {
        //transition code, can be removed if too complex
        SceneManager.LoadScene("jigsaws");
    }

    public void optionsClicked()
    {
        optionsUI.SetActive(true);
    }

     public void quitClicked()
    {
        print("since this is a web game, i dont think we need a quit button right?");
    }

}
