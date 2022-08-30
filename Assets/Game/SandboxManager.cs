using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SandboxManager : MonoBehaviour
{
    [SerializeField] StoryManager StoryManager;

    private bool firstChoice;

    void Start()
    {
        StoryManager.LoadStoryChunk();
        NPCEvents.GetInstance().NPCSelected += NPC_Selected;
    }

    private void OnDestroy()
    {
        NPCEvents.GetInstance().NPCSelected -= NPC_Selected;
    }

    void NPC_Selected(string name)
    {
        if(!StoryManager.WaitingForUserInteraction)
            return;
        
        if(name == "Fire")
            StoryManager.SetChoiceByText("Hablar con Fire");
        else if(name == "Goblin")
            StoryManager.SetChoiceByText("Hablar con Goblin");
    }
}