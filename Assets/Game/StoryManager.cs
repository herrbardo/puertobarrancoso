using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class StoryManager : MonoBehaviour
{
    [SerializeField] TextAsset InkJSON;
    [SerializeField] ScrollDialog ScrollDialog;
    
    private Story story;

    private void Start()
    {
        story = new Story(InkJSON.text);
        LoadStoryChunk();
    }

    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    public void LoadStoryChunk()
    {
        if(story.canContinue)
        {
            string text = story.ContinueMaximally();
            if(text == string.Empty || text == null)
                text = "END";
            
            ScrollDialog.AddDialogLine(text);
        }
    }

    public void LoadChoices()
    {
        foreach (Choice choice in story.currentChoices)
            ScrollDialog.AddChoice(choice.index, choice.text);
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
