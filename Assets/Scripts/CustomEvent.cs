using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomEvent
{
    public int position;
    public List<ImageInfo> images;
    public string dialogue;
    public string speaker;
    public bool isInteractable;
    public List<Option> options;
    public int nextDialoguePos;
    public bool isEnd;

}
