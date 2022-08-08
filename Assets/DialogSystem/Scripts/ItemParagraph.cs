using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class ItemParagraph : MonoBehaviour
{
    [SerializeField] float CharDisplayInterval;
    [SerializeField] TMP_Text ParagraphText;
    [NonSerialized] public string TextToDisplay;
    [NonSerialized] public ScrollDialog ParentSystem;
    [NonSerialized] public bool EndDisplay;

    void Start()
    {
        StartCoroutine(DisplayText());
    }

    private void Update()
    {
        if(Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame)
            EndDisplay = true;
    }

    IEnumerator DisplayText()
    {
        if(TextToDisplay != null)
        {
            ParagraphText.text = string.Empty;
            for (int i = 0; i < TextToDisplay.Length; i++)
            {
                ParagraphText.text += TextToDisplay[i];
                ParentSystem.ReportCharacaterDisplayed();
                yield return new WaitForSeconds(CharDisplayInterval);

                if(EndDisplay)
                {
                    ParagraphText.text = TextToDisplay;
                    break;
                }
            }
        ParentSystem.ReportParagraphDisplayFinished();
        }
        yield return null;
    }
}
