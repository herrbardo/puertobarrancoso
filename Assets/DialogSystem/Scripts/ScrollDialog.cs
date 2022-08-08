using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public delegate void UnscrolledDelegate();
public delegate void ChoiceSelectedDelegate(int id, string choiceText);
public delegate void ParagraphDisplayFinishedDelegate();

public class ScrollDialog : MonoBehaviour
{
    [SerializeField] SpriteRenderer ScrollSprite;
    [SerializeField] float RollDuration;
    [SerializeField] float MaxHeightToUnroll;
    [SerializeField] float MinHeightToRoll;
    [SerializeField] GameObject ItemParagraphPrefab;
    [SerializeField] GameObject ItemTextPrefab;
    [SerializeField] VerticalLayoutGroup LayoutGroup;
    [SerializeField] ScrollRect ScrollRect;
    [SerializeField] GameObject DialogChoicePrefab;
    [SerializeField] GameObject ScrollBar;

    private ItemParagraph _lastParagraph;
    private List<DialogChoice> _currentChoices;

    public ScrollDialog()
    {
        _currentChoices = new List<DialogChoice>();
    }

    #region Events

    public event UnscrolledDelegate Unscrolled;
    public event ChoiceSelectedDelegate ChoiceSelected;
    public event ParagraphDisplayFinishedDelegate ParagraphDisplayFinished;

    void OnUnscrolled()
    {
        if(Unscrolled != null)
            Unscrolled();
    }

    void OnChoiceSelected(int id, string choiceText)
    {
        if(ChoiceSelected != null)
            ChoiceSelected(id, choiceText);
    }

    void OnParagraphDisplayFinished()
    {
        if(ParagraphDisplayFinished != null)
            ParagraphDisplayFinished();
    }

    #endregion

    private void Start()
    {
        Hide();
    }

    public void Unroll()
    {
        StartCoroutine(Scroll(false, null));
    }

    public void Roll()
    {
        StartCoroutine(Scroll(true, Hide));
    }

    IEnumerator Scroll(bool up, Action callback)
    {
        float currentTime = 0;
        float start = ScrollSprite.size.y;
        float targetHeight = (up) ? MinHeightToRoll : MaxHeightToUnroll;

        while (currentTime < RollDuration)
        {
            currentTime += Time.deltaTime;
            float height = Mathf.Lerp(start, targetHeight, currentTime / RollDuration);
            ScrollSprite.size = new Vector2(ScrollSprite.size.x, height);
            yield return null;
        }

        if(!up)
        {
            SwitchScrollDisplay(true);
            OnUnscrolled();
        }
        
        if(callback != null)
            callback();

        yield return null;
    }

    public void AddDialogLine(string dialogText)
    {
        GameObject itemText = Instantiate(ItemTextPrefab);
        ItemParagraph paragraph = itemText.GetComponent<ItemParagraph>();
        paragraph.TextToDisplay = "-" + dialogText;
        paragraph.ParentSystem = this;
        SetupItem(itemText);
    }

    void SetupItem(GameObject gameObject)
    {
        gameObject.transform.SetParent(LayoutGroup.gameObject.transform);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        RectTransform rect = LayoutGroup.GetComponent<RectTransform>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        ScrollToBottom(true);
    }

    void Hide()
    {
        this.gameObject.SetActive(false);
        SwitchScrollDisplay(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        Unroll();
    }

    void ScrollToBottom(bool hard)
    {
        Canvas.ForceUpdateCanvases();
        if(hard)
            ScrollRect.verticalNormalizedPosition = -1;
        else
            ScrollRect.verticalNormalizedPosition = 0;
    }

    public void AddChoice(int id, string choiceText)
    {
        GameObject choice = Instantiate(DialogChoicePrefab);
        SetupItem(choice);
        DialogChoice dialogChoice = choice.GetComponent<DialogChoice>();
        dialogChoice.ParentSystem = this;
        dialogChoice.SetValues(id, string.Format("- {0}", choiceText));
        _currentChoices.Add(dialogChoice);
        ScrollToBottom(true);
    }

    public void ReportChoiceSelected(int choiceIndex, string choiceText)
    {
        foreach (DialogChoice currentChoice in _currentChoices)
        {
            if(currentChoice.ID == choiceIndex)
                continue;
            
            currentChoice.Disable();
        }
        _currentChoices = new List<DialogChoice>();

        OnChoiceSelected(choiceIndex, choiceText);
    }

    public void ReportParagraphDisplayFinished()
    {
        OnParagraphDisplayFinished();
    }

    public void ReportCharacaterDisplayed()
    {
        ScrollToBottom(false);
    }

    void SwitchScrollDisplay(bool displayOn)
    {
        float alpha = (displayOn) ? 255f : 0f;
        Image scrollContainer = this.ScrollBar.GetComponent<Image>();
        Image handleImage = this.ScrollBar.transform.GetChild(0).GetChild(0).GetComponent<Image>();

        scrollContainer.color = new Color(scrollContainer.color.r, scrollContainer.color.g, scrollContainer.color.b, alpha);
        handleImage.color = new Color(handleImage.color.r, handleImage.color.g, handleImage.color.b, alpha);
    }
}
