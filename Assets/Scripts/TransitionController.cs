using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public GameObject transitioner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator ShrinkCoroutine(string scene, Transform parent)
    {
        GameObject newTransition = Instantiate(transitioner, parent);
        newTransition.GetComponent<Transition>().Shrink();
        yield return new WaitForSecondsRealtime(0.8f);
        newTransition.GetComponent<Transition>().shrink = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    public IEnumerator ExpandCoroutine(Transform parent)
    {
        GameObject newTransition = Instantiate(transitioner, parent);
        newTransition.GetComponent<Transition>().Expand();
        yield return new WaitForSecondsRealtime(0.8f);
        newTransition.GetComponent<Transition>().expand= false;
        Time.timeScale = 1f;
        Destroy(newTransition);
    }

}
