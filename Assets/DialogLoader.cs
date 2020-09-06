using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class DialogLoader : MonoBehaviour,  IPointerClickHandler
{
    public int dialogId;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        DialogManager.Instance.ShowDialogWithId(dialogId, false);
    }
}
