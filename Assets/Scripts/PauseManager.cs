using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.InteropServices;

public class PauseManager : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void ScoreToStars (int score);
    public static bool gameIsPaused = true;
    
    [SerializeField] private GameObject Timecomponent;
    [SerializeField] private TMP_Text scorecomponent;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject winningUI;
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private GameObject audioPlayer;

    //transitioning object
    [SerializeField] private GameObject transitionControl;

    public int puzzleScore = 0;
    public int tallyScore = 0;
    private bool won = false;

    // Update is called once per frame
    void Start()
    {
        //Time.timeScale = 0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if((puzzleScore >= 9) && (won == false))
        {
            StartCoroutine(win());
            won = true;
        }
    }

    public void Resume()
    {
       if(won == false)
       {
        pauseMenuUI.SetActive(false);
        pauseMenuUI.transform.SetAsLastSibling();
        Time.timeScale = 1f;
        gameIsPaused = false;
       }
    }

    public void Pause()
    {
       if(won == false)
       {
        pauseMenuUI.SetActive(true);
        pauseMenuUI.transform.SetAsLastSibling();
        Time.timeScale = 0f;
        gameIsPaused = true;
       }
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("mainmenu");
        Time.timeScale = 1f;
        //StartCoroutine(transitionControl.GetComponent<TransitionController>().ShrinkCoroutine("mainmenu", this.transform));
    }

    //for winning screen specifically
    public IEnumerator win()
    {
        winningUI.SetActive(true);
        winningUI.transform.SetAsLastSibling();
        winningUI.transform.GetChild(0).transform.LeanMoveLocal(new Vector2(0,0), 0.5f).setIgnoreTimeScale(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        tallyScore = 600 - ((int)Timecomponent.GetComponent<CountDownTimer>().currentime);
        scorecomponent.SetText("Score:" + tallyScore.ToString());
        //wait for 1 second before enabling buttons
        yield return new WaitForSecondsRealtime(0.6f);
        winningUI.transform.Find("TweenPanel/PlayAgain").GetComponent<Button>().interactable = true;
        winningUI.transform.Find("TweenPanel/Menu").GetComponent<Button>().interactable = true;
        //ScoreToStars(tallyScore);
    }

    public void playAgain()
    {
        SceneManager.LoadScene("jigsaws");
        Time.timeScale = 1f;
        //StartCoroutine(transitionControl.GetComponent<TransitionController>().ShrinkCoroutine("jigsaws", this.transform));
    }

    public void bringUpPause()
    {
          if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
    }

    public void closeLoading()
    {
        loadingUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void incrementScore()
    {
        puzzleScore += 1;
    }

}
