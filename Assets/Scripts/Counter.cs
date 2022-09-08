using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TMP_Text txt;
    private int count;
    private PlayerController script;
    void Start()
    {
        script = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        count = script.count;
        txt.text = count.ToString("Stars Collected: "+count);
    }
}
