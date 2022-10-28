using PixelCrushers.DialogueSystem.Wrappers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;
    public DialogueSystemController DialogueSystemController;

    private void Awake()
    {
        Instance = this;
       
    }

    private void Start()
    {
        DialogueSystemController.conversationEnded += DialogueSystemController_conversationEnded;
    }

    private void DialogueSystemController_conversationEnded(Transform t)
    {
        //SequenceManager.Instance.Continue();
    }

    public void ShowDialogue(string title)
    {
        DialogueSystemController.StartConversation(title);
    }

}
