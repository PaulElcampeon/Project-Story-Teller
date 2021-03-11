using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPaglet : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    public void Back()
    {
        _panel.SetActive(false);
    }
}
