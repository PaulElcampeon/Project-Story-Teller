using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprites;

    [SerializeField]
    private Image _jaceImage, _backgroundImage, _deskImage, _dialogImage, _judgeImage, _lawyerImage,
        _prosecutorImage, _timmyImage;

    private Dictionary<string, Sprite> _spriteDictionary = new Dictionary<string, Sprite>(150);

    public static UiManager INSTANCE;

    private void Awake()
    {
        INSTANCE = this;

        foreach(Sprite sprite in _sprites)
        {
            string spriteName = sprite.name.ToLower();
            if (!_spriteDictionary.ContainsKey(spriteName)) _spriteDictionary.Add(spriteName, sprite);
        }
    }

    public void SetImage(string image, string desc, Vector2 pos, float rotation)
    {
        desc = desc.ToLower();

        image = image.ToLower();

        switch (image)
        {
            case "jace":
                SetJaceImage(desc, pos, rotation);
                break;
            case "timmy":
                SetTimmyImage(desc, pos, rotation);
                break;
            case "lawyer":
                SetLawyerImage(desc, pos, rotation);
                break;
            case "prosecutor":
                SetProsecutorImage(desc, pos, rotation);
                break;
            case "judge":
                SetJudgeImage(desc, pos, rotation);
                break;
            case "background":
                SetBackgroundImage(desc, pos, rotation);
                break;
            case "desk":
                SetDeskImage(desc, pos, rotation);
                break;
            case "dialogue":
                break;
            default:
                break;

        }
    }

    public void SetTimmyImage(string expression, Vector2 pos, float rotation)
    {

        if (_spriteDictionary.TryGetValue(expression, out Sprite sprite)) _timmyImage.sprite = sprite;


        RectTransform rect = _timmyImage.gameObject.GetComponent<RectTransform>();
        rect.localPosition = pos;
        rect.localRotation = Quaternion.Euler(0, rotation, 0);

        _timmyImage.gameObject.SetActive(true);
    }

    public void SetJaceImage(string expression, Vector2 pos, float rotation)
    {
        Debug.Log(expression);

        Debug.Log(_spriteDictionary.ContainsKey(expression));


        if(_spriteDictionary.TryGetValue(expression, out Sprite sprite)) _jaceImage.sprite = sprite;

        RectTransform rect = _jaceImage.gameObject.GetComponent<RectTransform>();
        rect.localPosition = pos;
        rect.localRotation = Quaternion.Euler(0, rotation, 0);

        _jaceImage.gameObject.SetActive(true);
    }

    public void SetDeskImage(string position, Vector2 pos, float rotation)
    {
        if (_spriteDictionary.TryGetValue(position, out Sprite sprite)) _deskImage.sprite = sprite;


        _deskImage.gameObject.SetActive(true);
    }

    public void SetBackgroundImage(string position, Vector2 pos, float rotation)
    {

        if (_spriteDictionary.TryGetValue(position, out Sprite sprite)) _backgroundImage.sprite = sprite;


        _backgroundImage.gameObject.SetActive(true);
    }

    public void SetJudgeImage(string expression, Vector2 pos, float rotation)
    {

        if (_spriteDictionary.TryGetValue(expression, out Sprite sprite)) _judgeImage.sprite = sprite;


        _judgeImage.gameObject.SetActive(true);
    }

    public void SetLawyerImage(string expression, Vector2 pos, float rotation)
    {
        if (_spriteDictionary.TryGetValue(expression, out Sprite sprite)) _lawyerImage.sprite = sprite;


        _lawyerImage.gameObject.SetActive(true);
    }

    public void SetProsecutorImage(string expression, Vector2 pos, float rotation)
    {

        if (_spriteDictionary.TryGetValue(expression, out Sprite sprite)) _prosecutorImage.sprite = sprite;


        _prosecutorImage.gameObject.SetActive(true);
    }

    public void EnableDialogbox()
    {
        _dialogImage.gameObject.SetActive(true);
    }

    public void DisableDialogbox()
    {
        _dialogImage.gameObject.SetActive(false);
    }


    public Image JaceImage { get => _jaceImage; set => _jaceImage = value; }
    public Image BackgroundImage { get => _backgroundImage; set => _backgroundImage = value; }
    public Image DeskImage { get => _deskImage; set => _deskImage = value; }
    public Image DialogImage { get => _dialogImage; set => _dialogImage = value; }
    public Image JudgeImage { get => _judgeImage; set => _judgeImage = value; }
    public Image LawyerImage { get => _lawyerImage; set => _lawyerImage = value; }
    public Image ProsecutorImage { get => _prosecutorImage; set => _prosecutorImage = value; }
}
