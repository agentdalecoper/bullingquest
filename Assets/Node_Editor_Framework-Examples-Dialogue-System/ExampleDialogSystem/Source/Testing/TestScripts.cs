using UnityEngine;

public class TestScripts : MonoBehaviour
{
    [SerializeField] private DialogManager _dialogManager;
    public int DialogIdToLoad = 1;
    public float value = 0.1f;


    void Start()
    {
        DialogBlackboard.SetValue(DialogBlackboard.EDialogMultiChoiceVariables.TryingThisToo, value);

        Debug.Log("TestScript Update about to load dialog " + DialogIdToLoad);
        _dialogManager.ShowDialogWithId(DialogIdToLoad, true);
    }

    void Update()
    {
    }
}