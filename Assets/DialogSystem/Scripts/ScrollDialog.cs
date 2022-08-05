using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollDialog : MonoBehaviour
{
    [SerializeField] SpriteRenderer ScrollSprite;
    [SerializeField] float UnrollDuration;
    [SerializeField] float MaxHeightToUnroll;
    [SerializeField] GameObject ItemParagraphPrefab;
    [SerializeField] GameObject BaseText;
    [SerializeField] VerticalLayoutGroup LayoutGroup;

    private ItemParagraph _lastParagraph;

    private void Start()
    {
        Hide();
    }

    public void Unroll()
    {
        StartCoroutine(OpenScroll());
    }

    IEnumerator OpenScroll()
    {
        float currentTime = 0;
        float start = ScrollSprite.size.y;

        while (currentTime < UnrollDuration)
        {
            currentTime += Time.deltaTime;
            float height = Mathf.Lerp(start, MaxHeightToUnroll, currentTime / UnrollDuration);
            ScrollSprite.size = new Vector2(ScrollSprite.size.x, height);
            yield return null;
        }

        yield return null;
    }

    public void AddDialogLine(string dialogText)
    {
        // GameObject copyBaseText = Instantiate(BaseText);
        // SetupItem(copyBaseText);
        // TMP_Text textComponent = copyBaseText.GetComponent<TMP_Text>();
        // textComponent.text = dialogText;
        GameObject paragraph = Instantiate(ItemParagraphPrefab);
        SetupItem(paragraph);
        ItemParagraph item = paragraph.GetComponent<ItemParagraph>();
        item.TextToDisplay = dialogText;
    }

    void SetupItem(GameObject gameObject)
    {
        gameObject.transform.SetParent(LayoutGroup.gameObject.transform);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        RectTransform rect = LayoutGroup.GetComponent<RectTransform>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        //ScrollToBottom(true);
    }

    void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        Unroll();
    }
}
