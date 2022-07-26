using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class StoryManager : MonoBehaviour
{
    [SerializeField] TextAsset InkJSON;
    [SerializeField] DialogSystem DialogSystem;
    
    private Story story;

    private void Start()
    {
        story = new Story(InkJSON.text);
        DialogSystem.ChoiceSelected += ChoiceSelected;
        DialogSystem.ParagraphDisplayFinished += ParagraphDisplayFinished;
        LoadStoryChunk();
    }

    private void Update()
    {
        if(Input.anyKey)
            DialogSystem.ForceEndDisplay();
    }

    private void OnDestroy()
    {
        DialogSystem.ChoiceSelected -= ChoiceSelected;
        DialogSystem.ParagraphDisplayFinished -= ParagraphDisplayFinished;
    }

    void LoadStoryChunk()
    {
        if(story.canContinue)
        {
            string text = story.ContinueMaximally();
            if(text == string.Empty || text == null)
                text = "END";
            
            DialogSystem.AddDialogLine(text);
        }
    }

    void LoadChoices()
    {
        foreach (Choice choice in story.currentChoices)
            DialogSystem.AddChoice(choice.index, choice.text);
    }

    void ChoiceSelected(int choiceIndex, string choiceText)
    {
        story.ChooseChoiceIndex(choiceIndex);
        LoadStoryChunk();
    }

    void ParagraphDisplayFinished()
    {
        if(story.currentChoices.Count == 0)
            LoadStoryChunk();
        else
            LoadChoices();
    }
}
