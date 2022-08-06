using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//public delegate void ChoiceSelectedDelegate(int id, string choiceText);
public delegate void ParagraphDisplayFinishedDelegate();
public class DialogSystem : MonoBehaviour
{
    [SerializeField] GameObject ItemParagraphPrefab;
    [SerializeField] GameObject DialogChoicePrefab;
    [SerializeField] VerticalLayoutGroup LayoutGroup;
    [SerializeField] ScrollRect ScrollRect;
    [SerializeField] RectTransform Rect;
    [SerializeField] float UnrollDuration;

    private List<DialogChoice> _currentChoices;
    private ItemParagraph _lastParagraph;
    private float _targetSize;

    public event ChoiceSelectedDelegate ChoiceSelected;
    public event ParagraphDisplayFinishedDelegate ParagraphDisplayFinished;

    public DialogSystem()
    {
        _currentChoices = new List<DialogChoice>();
    }

    private void Start()
    {
        _targetSize = Rect.sizeDelta.y;
        Rect.sizeDelta = new Vector2(Rect.sizeDelta.x, 50f);
        StartCoroutine(Unroll());
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

    public void AddDialogLine(string dialogText)
    {
        GameObject paragraph = Instantiate(ItemParagraphPrefab);
        SetupItem(paragraph);
        ItemParagraph itemParagraph = paragraph.GetComponent<ItemParagraph>();
        itemParagraph.TextToDisplay = string.Format("- {0}", dialogText);
        itemParagraph.ParentSystem = this;
        _lastParagraph = itemParagraph;
    }

    public void AddChoice(int id, string choiceText)
    {
        GameObject choice = Instantiate(DialogChoicePrefab);
        SetupItem(choice);
        DialogChoice dialogChoice = choice.GetComponent<DialogChoice>();
        //dialogChoice.ParentSystem = this;
        dialogChoice.SetValues(id, string.Format("- {0}", choiceText));
        _currentChoices.Add(dialogChoice);
    }

    void SetupItem(GameObject gameObject)
    {
        gameObject.transform.SetParent(LayoutGroup.gameObject.transform);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        RectTransform rect = LayoutGroup.GetComponent<RectTransform>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
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

    void ScrollToBottom(bool hard)
    {
        if(hard)
            ScrollRect.verticalNormalizedPosition = -1;
        else
            ScrollRect.verticalNormalizedPosition = 0;
    }

    public void ForceEndDisplay()
    {
        if(_lastParagraph != null)
            _lastParagraph.EndDisplay = true;
    }

    IEnumerator Unroll()
    {
        float currentTime = 0;
        float start = Rect.sizeDelta.y;

        while (currentTime < UnrollDuration)
        {
            currentTime += Time.deltaTime;
            float height = Mathf.Lerp(start, _targetSize, currentTime / UnrollDuration);
            Rect.sizeDelta = new Vector2(Rect.sizeDelta.x, height);
            yield return null;
        }
    }
}
