using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LawController : MonoBehaviour
{
    public int level;

    private static LawController instance;
    public static LawController Instance => instance;

    public TextMeshProUGUI textValue;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        textValue.text = level.ToString();
    }
}