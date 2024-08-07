using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private RectTransform mask;
    public bool shrink = false;
    public bool expand = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Awake()
    {
        mask = this.transform.Find("transition").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shrink == true)
        {
            mask.sizeDelta -= new Vector2(4,4);
        }

        if(expand == true)
        {
            mask.sizeDelta += new Vector2(4,4);
        }
    }

    public void Shrink()
    {
       print("shrinking");
       this.gameObject.SetActive(true);
       this.gameObject.transform.SetAsLastSibling();
       shrink = true;
    }

    public void Expand()
    {
       print("expanding");
       this.gameObject.SetActive(true);
       this.gameObject.transform.SetAsLastSibling();
       mask.sizeDelta = new Vector2(0,0);
       expand = true;
    }

}
