﻿using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private static DialogManager instance;
    public static DialogManager Instance => instance;
    
    private Dictionary<int, DialogNodeCanvas> _dialogIdTracker;

    [SerializeField] private GameObject _messageBoxPrefab;
    private Dictionary<int, MessageBoxHud> _messageBoxes;

    [SerializeField] private RectTransform _canvasObject;

    public DialogNodeCanvas dialogCanvas;

    private int dialogPointer = 0;
    public List<DialogLoader> dialogLoaders;
    public DialogLoader activeDialogLoader;

    public void Awake()
    {
        instance = this;
        
        
        _messageBoxes = new Dictionary<int, MessageBoxHud>();
        _dialogIdTracker = new Dictionary<int, DialogNodeCanvas>();
        _dialogIdTracker.Clear();

        if (dialogCanvas)
        {
            foreach (int id in dialogCanvas.GetAllDialogId())
            {
                _dialogIdTracker.Add(id, dialogCanvas);
            }
        }
        else
        {
            foreach (DialogNodeCanvas nodeCanvas in Resources.LoadAll<DialogNodeCanvas>("Saves/"))
            {
                foreach (int id in nodeCanvas.GetAllDialogId())
                {
                    _dialogIdTracker.Add(id, nodeCanvas);
                }
            }
        }
    }

    public void ShowDialogWithId(int dialogIdToLoad, bool goBackToBeginning)
    {
        if (_messageBoxes.ContainsKey(dialogIdToLoad))
        {
            return;
        }

        DialogNodeCanvas nodeCanvas;
        if (_dialogIdTracker.TryGetValue(dialogIdToLoad, out nodeCanvas))
        {
            nodeCanvas.ActivateDialog(dialogIdToLoad, goBackToBeginning);
        }
        else
        {
            Debug.LogError("ShowDialogWithId Not found Dialog with ID : " + dialogIdToLoad);
            return;
        }

        MessageBoxHud messageBox = _messageBoxPrefab.GetComponent<MessageBoxHud>();
        messageBox.gameObject.SetActive(true);


        messageBox.Construct(dialogIdToLoad, this);
        messageBox.transform.SetParent(_canvasObject, false);
        messageBox.SetData(GetNodeForId(dialogIdToLoad));
        _messageBoxes.Add(dialogIdToLoad, messageBox);
    }

    private BaseDialogNode GetNodeForId(int dialogIdToLoad)
    {
        DialogNodeCanvas nodeCanvas;
        if (_dialogIdTracker.TryGetValue(dialogIdToLoad, out nodeCanvas))
        {
            return nodeCanvas.GetDialog(dialogIdToLoad);
        }
        else
            Debug.LogError("getNodeForId Not found Dialog with ID : " + dialogIdToLoad);

        return null;
    }

    private void GiveInputToDialog(int dialogIdToLoad, int inputValue)
    {
        DialogNodeCanvas nodeCanvas;
        if (_dialogIdTracker.TryGetValue(dialogIdToLoad, out nodeCanvas))
        {
            if (nodeCanvas.InputToDialog(dialogIdToLoad, inputValue) == false)
            {
                _messageBoxPrefab.gameObject.SetActive(false);
            }
        }
        else
            Debug.LogError("GiveInputToDialog Not found Dialog with ID : " + dialogIdToLoad);
    }

    public void OkayPressed(int dialogId)
    {
        GiveInputToDialog(dialogId, (int) EDialogInputValue.Next);
        _messageBoxes[dialogId].SetData(GetNodeForId(dialogId));
    }

    public void BackPressed(int dialogId)
    {
        GiveInputToDialog(dialogId, (int) EDialogInputValue.Back);
        _messageBoxes[dialogId].SetData(GetNodeForId(dialogId));
    }

    public void RemoveMessageBox(int dialogId)
    {
        _messageBoxPrefab.gameObject.SetActive(false);
        activeDialogLoader.gameObject.SetActive(false);
        dialogPointer++;
        activeDialogLoader = dialogLoaders[dialogPointer];
        activeDialogLoader.gameObject.SetActive(true);

        //dialogId = dialogId + 1;
        //ShowDialogWithId(dialogId, false);
    }

    public void OptionSelected(int dialogId, int optionSelected)
    {
        GiveInputToDialog(dialogId, optionSelected);
        _messageBoxes[dialogId].SetData(GetNodeForId(dialogId));
    }
}

public enum EDialogInputValue
{
    Next = -2,
    Back = -1,
}