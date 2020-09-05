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

    private TextMeshProUGUI textValue;

    private void Awake()
    {
        instance = this;
        textValue = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        textValue.text = level.ToString();
    }
}