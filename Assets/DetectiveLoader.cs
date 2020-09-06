using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveLoader : DialogLoader
{
    public int detectiveThreshold;

    private void Start()
    {
        if (LawController.Instance.level >= detectiveThreshold)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}