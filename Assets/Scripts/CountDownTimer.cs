using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public TMP_Text textcomponent;
    public float currentime;
    // Start is called before the first frame update
    void Start()
    {
        currentime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentime += 1 * Time.deltaTime;
        textcomponent.SetText("Time:" + ((int)currentime).ToString());
    }
}
