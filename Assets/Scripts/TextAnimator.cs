using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimator : MonoBehaviour
{
    public TMP_Text textComponent;
    public string textanim = "wobbly";
    public bool timeunscale =  false;
    Textanimations textanimate = new Textanimations();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textanimate.textAnim(textComponent, textanim, timeunscale);
    }
}
