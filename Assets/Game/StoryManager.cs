using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System;

public class StoryManager : MonoBehaviour
{
    [SerializeField] TextAsset InkJSON;
    [SerializeField] ScrollDialog ScrollDialog;
    [NonSerialized] public bool WaitingForUserInteraction;
    
    private Story story;

    private void Awake()
    {
        ScrollDialog.ChoiceSelected += ChoiceSelected;
        ScrollDialog.ParagraphDisplayFinished += ParagraphDisplayFinished;
    }

    private void Start()
    {
        story = new Story(InkJSON.text);
    }

    private void OnDestroy()
    {
        ScrollDialog.ChoiceSelected -= ChoiceSelected;
        ScrollDialog.ParagraphDisplayFinished -= ParagraphDisplayFinished;
    }

    public void LoadStoryChunk()
    {
        if(story.canContinue)
        {
            string text = story.ContinueMaximally();
            StoryMetadata metadata = new StoryMetadata(story);

            if(metadata.Type == NodeType.TEXT)
            {
                WaitingForUserInteraction = false;
                if(text == string.Empty || text == null)
                    text = "END";
                ScrollDialog.AddDialogLine(text, true, metadata.Speaker);
            }
            else if(metadata.Type == NodeType.INTERACTION)
            {
                WaitingForUserInteraction = true;
                ScrollDialog.AddDialogLine("[...]", false, string.Empty);
            }
        }
    }

    public void LoadChoices()
    {
        foreach (Choice choice in story.currentChoices)
            ScrollDialog.AddChoice(choice.index, choice.text);
    }

    void ChoiceSelected(int choiceIndex, string choiceText)
    {
        SetChoiceByIndex(choiceIndex);
    }

    void ParagraphDisplayFinished()
    {
        if(WaitingForUserInteraction)
            return;
        
        if(story.currentChoices.Count == 0)
            LoadStoryChunk();
        else
            LoadChoices();
    }

    public void SetChoiceByIndex(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        LoadStoryChunk();
    }

    public void SetChoiceByText(string choiceText)
    {
        foreach (Choice currentChoice in story.currentChoices)
        {
            if(currentChoice.text.Equals(choiceText))
            {
                SetChoiceByIndex(currentChoice.index);
                break;
            }
        } 
    }
}
