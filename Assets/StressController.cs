using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StressController : MonoBehaviour
{
    public int level;
    
    private static StressController instance;
    public static StressController Instance => instance;

    public TextMeshProUGUI textValue;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        textValue.text = level.ToString();
    }
}