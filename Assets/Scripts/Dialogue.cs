using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textDisplay;

    [SerializeField]
    private TextMeshProUGUI _speakerDisplay;

    [SerializeField]
    private float _typeSpeed;

    [SerializeField]
    private GameObject _continueButton;

    private int _index;

    private float _originalTypeSpeed;

    public TextAsset jsonFile;

    private EventCollection customEvents;

    void Start()
    {
        _originalTypeSpeed = _typeSpeed;

        customEvents = JsonLoader.Load(jsonFile.text);

        _index = 0;

        _textDisplay.text = "";

        StartCoroutine(Type());
    }

    void Update()
    {
        DisplaySpeaker();

        ListenToKeyInteraction();

        ListenForPlayerReturnKey();
    }

    private void DisplaySpeaker()
    {
        if (customEvents.events[_index].speaker != "")
        {
            _speakerDisplay.text = customEvents.events[_index].speaker;
        }
    }

    private void ListenForPlayerReturnKey()
    {
        if (customEvents.events[_index].isInteractable) return;

        if (_textDisplay.text == customEvents.events[_index].dialogue)
        {

            if (customEvents.events[_index].isEnd) return;
            //_continueButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                NextSentence();
            }
        }
    }

    private void ListenToKeyInteraction()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _typeSpeed = _originalTypeSpeed / 2;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _typeSpeed = _originalTypeSpeed;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _textDisplay.text = customEvents.events[_index].dialogue;

        }
    }

    private IEnumerator Type()
    {
        //_typeSpeed = _originalTypeSpeed;

        foreach (ImageInfo imageInfo in customEvents.events[_index].images)
        {
            UiManager.INSTANCE.SetImage(imageInfo.imgSource.ToLower(), imageInfo.description.ToLower(), imageInfo.pos, imageInfo.rotation);
        }

        UiManager.INSTANCE.EnableDialogbox();

        foreach (char letter in customEvents.events[_index].dialogue.ToCharArray())
        {
            SoundManager.INSTANCE.PlaySFX(0); //Typing sound

            if (_textDisplay.text == customEvents.events[_index].dialogue)
            {
                break;
            }

            _textDisplay.text += letter;

            yield return new WaitForSeconds(_typeSpeed);
        }

        ActivateOptions();
    }

    public void NextSentence()
    {
        UiManager.INSTANCE.DisableDialogbox();

        DeactivateOptions();

        _index = customEvents.events[_index].nextDialoguePos;

        _textDisplay.text = "";

        StartCoroutine(Type());
    }

    public void NextSentence(int index)
    {
        DeactivateOptions();

        _index = index;

        _textDisplay.text = "";

        StartCoroutine(Type());
    }

    public void AddFunctionToButtons(string option, int positionToLeadTo)
    {
        CustomDelegate.MyCustomDelegate de = NextSentence;

        DialoguePanel.INSTANCE.AddFunctionToOption(option.ToUpper(), de, positionToLeadTo);
    }

    private void ActivateOptions()
    {
        if (!customEvents.events[_index].isInteractable) return;

        foreach (Option op in customEvents.events[_index].options)
        {
            AddFunctionToButtons(op.buttonOption, op.newPosition);
        }

        ListenForPlayerReturnKey();
    }

    private void DeactivateOptions()
    {
        DialoguePanel.INSTANCE.RemoveListenersFromButtons();

        DialoguePanel.INSTANCE.DisableAllOptions();
    }


    //public void NextSentence()
    //{
    //    //_continueButton.SetActive(false);

    //    if (_index < sentences.Length - 1) {
    //        _index++;
    //        _textDisplay.text = "";
    //        StartCoroutine(Type());
    //    }
    //    else
    //    {
    //        _textDisplay.text = "";
    //    }
    //}

}
