using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogChoice : MonoBehaviour
{
    [SerializeField] Color AvailableColor;
    [SerializeField] Color HoverColor;
    [SerializeField] Color SelectedColor;
    [SerializeField] TMP_Text ChoiceText;
    [SerializeField] bool Available;
    [SerializeField] Button ButtonContainer;
    [SerializeField] public int ID;
    [SerializeField] public DialogSystem ParentSystem;

    bool choiceSelected;

    
    private void Update()
    {
        SetColors();
    }

    void SetColors()
    {
        ColorBlock block = ButtonContainer.colors;

        if(Available)
        {
            block.normalColor = AvailableColor;
            block.highlightedColor = HoverColor;
            block.selectedColor = SelectedColor;
        }
        else if(choiceSelected)
        {
            block.normalColor = SelectedColor;
            block.highlightedColor = SelectedColor;
            block.selectedColor = SelectedColor;
        }
        else
        {
            block.normalColor = AvailableColor;
            block.highlightedColor = AvailableColor;
            block.selectedColor = AvailableColor;
        }

        ButtonContainer.colors = block;
    }

    public void Choice_Click()
    {
        if(choiceSelected || !Available)
            return;
        
        choiceSelected = true;
        Available = false;
        ParentSystem.ReportChoiceSelected(ID, ChoiceText.text);
    }

    public void Disable()
    {
        Available = false;
    }

    public void SetValues(int id, string text)
    {
        ChoiceText.text = text;
        ID = id;
    }
}
