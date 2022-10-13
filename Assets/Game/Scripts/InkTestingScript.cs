using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class InkTestingScript : MonoBehaviour
{
    [SerializeField] TextAsset inkJSON;
    [SerializeField] TMP_Text DialogText;
    [SerializeField] TMP_Text StoryState;
    [SerializeField] GameObject ButtonChoicePrefab;
    [SerializeField] HorizontalLayoutGroup LayoutChoices;
    private Story story;
    StringBuilder textBuilder;

    void Start()
    {
        story = new Story(inkJSON.text);
        textBuilder = new StringBuilder();
        LoadStoryChunk();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        StoryState.text = string.Format("HasError: {0} HasWarning: {1}", story.hasError, story.hasWarning);
    }

    void LoadStoryChunk(string choiceText)
    {
        if(story.canContinue)
        {
            string text = story.ContinueMaximally();

            if(text == string.Empty || text == null)
            {
                text = "END";
            }
            else if(choiceText != null)
            {
                text = text.Replace(choiceText + ".", "");
                textBuilder.AppendLine("[" + choiceText + "]");
            }

            textBuilder.AppendLine(text);
            DialogText.text = textBuilder.ToString();

            CheckForChoices();
        }
    }

    void LoadStoryChunk()
    {
        LoadStoryChunk(null);
    }

    void CheckForChoices()
    {
        foreach (Choice choice in story.currentChoices)
        {
            GameObject buttonChoice = Instantiate(this.ButtonChoicePrefab);
            buttonChoice.transform.SetParent(LayoutChoices.transform);
            buttonChoice.transform.localScale = new Vector3(1f, 1f, 1f);

            ButtonChoice choiceManager = buttonChoice.GetComponent<ButtonChoice>();
            choiceManager.SetValues(choice.text, choice.index);
            choiceManager.Father = this;
        } 
    }

    public void ChoiceSelected(int choiceIndex, string choiceText)
    {
        story.ChooseChoiceIndex(choiceIndex);
        KillChildren();
        LoadStoryChunk(choiceText);
    }

    void KillChildren()
    {
        foreach (Transform childButton in LayoutChoices.transform)
            Destroy(childButton.gameObject);
    }
}


