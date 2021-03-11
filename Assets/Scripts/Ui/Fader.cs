using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private float _timeToFade;

    private bool _shouldFadeOut, _isActive;

    private Image _panelImage;

    public static Fader INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

    void Start()
    {
        _panelImage = _panel.GetComponent<Image>();
    }

    void Update()
    {
        if (!_isActive) return;

        float alpha = _panelImage.color.a;

        if (_shouldFadeOut)
        {
            alpha = alpha + (Time.deltaTime / _timeToFade);

            _panelImage.color = new Color(0, 0, 0, alpha);

            if (alpha >= 1f) _isActive = false;
        }
        else
        {
            alpha = alpha - (Time.deltaTime / _timeToFade);

            _panelImage.color = new Color(0, 0, 0, alpha);

            if (alpha <= 1f) _isActive = false;
        }
    }

    public void FadeOut()
    {
        _shouldFadeOut = true;

        _isActive = true;
    }

    public void FadeIn()
    {
        _shouldFadeOut = false;

        _isActive = true;
    }

    public bool IsActive()
    {
        return _isActive;
    }
}
