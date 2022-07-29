using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ButtonChoice : MonoBehaviour
{
    [SerializeField] TMP_Text ButtonText;
    [NonSerialized] public InkTestingScript Father;
    int _choiceIndex;

    public void ButtonChoice_Click()
    {
        Father.ChoiceSelected(this._choiceIndex, ButtonText.text);
    }

    public void SetValues(string choiceText, int choideIndex)
    {
        ButtonText.text = choiceText;
        this._choiceIndex = choideIndex;
    }
}
