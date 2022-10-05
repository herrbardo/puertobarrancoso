using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PixelCrushers.DialogueSystem.Wrappers;
using System;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class UserControl : MonoBehaviour
{
    [SerializeField] DialogueSystemController DialogSystemController;
    [SerializeField] float ForwardCooldown;

    bool enableForward;

    private void Start()
    {
        enableForward = true;
    }

    void ConversationStart(Transform t)
    {
        Debug.Log("VERGA " + DateTime.Now);
    }
    
    public void ForwardDialog(InputAction.CallbackContext context)
    {
        if(!enableForward)
            return;

        Forward();
        enableForward = false;
        Invoke("EnableFordwarding", ForwardCooldown);
    }

    void Forward()
    {
        GameObject continueButtonGameObject = GameObject.Find("Continue Button");
        if(continueButtonGameObject == null)
            return;

        StandardUIContinueButtonFastForward continueButton = continueButtonGameObject.GetComponent<StandardUIContinueButtonFastForward>();
        if(continueButton == null)
            return;
        
        continueButton.OnFastForward();
    }

    void EnableFordwarding()
    {
        enableForward = true;
    }

    public void SkipDialog(InputAction.CallbackContext context)
    {
        if(!enableForward)
            return;

        Forward();
        Forward();
        enableForward = false;
        Invoke("EnableFordwarding", ForwardCooldown);
    }

    public void ChooseOption(InputAction.CallbackContext context)
    {
        // if(!enableForward)
        //     return;

        // Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        // if(button != null && button.gameObject.name.StartsWith("Response"))
        // {
        //     Debug.Log("VERGA");
        //     StandardUIResponseButton responseButton = button.gameObject.GetComponent<StandardUIResponseButton>();
        //     responseButton.OnClick();
        // }

        // enableForward = false;
        // Invoke("EnableFordwarding", ForwardCooldown);
    }

    public void Back()
    {
        if(!enableForward)
            return;

        var backer = DialogSystemController.gameObject.GetComponent<PixelCrushers.DialogueSystem.Backtracker>();
        backer.Backtrack(true);

        enableForward = false;
        Invoke("EnableFordwarding", ForwardCooldown);
    }
}
