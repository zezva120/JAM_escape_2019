using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public void Display(string _text)
    {
        text.text = _text;
    }
}
