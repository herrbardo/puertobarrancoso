using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ItemParagraph : MonoBehaviour
{
    [SerializeField] float CharDisplayInterval;
    [SerializeField] TMP_Text ParagraphText;
    [NonSerialized] public string TextToDisplay;
    [NonSerialized] public DialogSystem ParentSystem;
    [NonSerialized] public bool EndDisplay;

    void Start()
    {
        StartCoroutine(DisplayText());
    }

    IEnumerator DisplayText()
    {
        if(TextToDisplay != null)
            for (int i = 0; i < TextToDisplay.Length; i++)
            {
                ParagraphText.text += TextToDisplay[i];
                //ParentSystem.ReportCharacaterDisplayed();
                yield return new WaitForSeconds(CharDisplayInterval);

                if(EndDisplay)
                {
                    ParagraphText.text = TextToDisplay;
                    break;
                }
            }

        //ParentSystem.ReportParagraphDisplayFinished();
        yield return null;
    }
}
