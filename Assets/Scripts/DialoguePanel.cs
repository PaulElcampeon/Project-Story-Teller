using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    [SerializeField]
    private Button _optionA, _optionB, _optionC, _optionD;

    public static DialoguePanel INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

    public Button GetButtonOptionA() {
        return _optionA;
    }

    public Button GetButtonOptionB()
    {
        return _optionB;
    }

    public Button GetButtonOptionC()
    {
        return _optionC;
    }

    public Button GetButtonOptionD()
    {
        return _optionD;
    }

    public void EnableAllOptions()
    {
        _optionA.gameObject.SetActive(true);
        _optionB.gameObject.SetActive(true);
        _optionC.gameObject.SetActive(true);
        _optionD.gameObject.SetActive(true);
    }

    public void DisableAllOptions()
    {
        _optionA.gameObject.SetActive(false);
        _optionB.gameObject.SetActive(false);
        _optionC.gameObject.SetActive(false);
        _optionD.gameObject.SetActive(false);
    }

    public void AddFunctionToOption(string optionLetter, CustomDelegate.MyCustomDelegate func, int positionToLeadTo)
    {
        switch(optionLetter)
        {
            case "A":
                if (!_optionA.IsActive())
                {
                    _optionA.onClick.AddListener(() => func(positionToLeadTo));
                    _optionA.gameObject.SetActive(true);
                }
                break;
            case "B":
                if (!_optionB.IsActive())
                {
                    _optionB.onClick.AddListener(() => func(positionToLeadTo));
                    _optionB.gameObject.SetActive(true);
                }
                break;
            case "C":
                if (!_optionC.IsActive())
                {
                    _optionC.onClick.AddListener(() => func(positionToLeadTo));
                    _optionC.gameObject.SetActive(true);
                }
                break;
            case "D":
                if (!_optionD.IsActive())
                {
                    _optionD.onClick.AddListener(() => func(positionToLeadTo));
                    _optionD.gameObject.SetActive(true);
                }
                break;
            default:
                break;

        }
    }

    public void RemoveListenersFromButtons()
    {
        _optionA.onClick.RemoveAllListeners();
        _optionB.onClick.RemoveAllListeners();
        _optionC.onClick.RemoveAllListeners();
        _optionD.onClick.RemoveAllListeners();
    }
}
