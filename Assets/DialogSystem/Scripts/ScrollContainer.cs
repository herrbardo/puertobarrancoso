using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ScrollContainer : MonoBehaviour
{
    public void FilterBySpeaker(string speaker)
    {
        ClearFilter();
        List<ItemParagraph> items = gameObject.GetComponentsInChildren<ItemParagraph>().ToList();
        List<DialogChoice> choices = gameObject.GetComponentsInChildren<DialogChoice>().ToList();

        foreach (ItemParagraph item in items)
        {
            if(item.Metadata == null || item.Metadata.Speaker == null)
                continue;
            if(!item.Metadata.Speaker.Equals(speaker))
            {
                Debug.Log("METADATA SPEAKER: " + item.Metadata.Speaker + " " + DateTime.Now);
                item.gameObject.SetActive(false);
            }
        }

        foreach (DialogChoice choice in choices)
        {
            if(choice.Metadata == null || choice.Metadata.Speaker == null)
                continue;
            if(!choice.Metadata.Speaker.Equals(speaker))
                choice.gameObject.SetActive(false);
        }
    }

    public void ClearFilter()
    {
        List<ItemParagraph> items = gameObject.GetComponentsInChildren<ItemParagraph>().ToList();
        List<DialogChoice> choices = gameObject.GetComponentsInChildren<DialogChoice>().ToList();

        foreach (ItemParagraph item in items)
            item.gameObject.SetActive(true);
        foreach (DialogChoice choice in choices)
            choice.gameObject.SetActive(true);
    }
}
