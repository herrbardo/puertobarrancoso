using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PixelCrushers.DialogueSystem.Wrappers;
using PixelCrushers.Wrappers;

public class UserControl : MonoBehaviour
{
    [SerializeField] InputActionReference InputUserControl;
    [SerializeField] DialogueSystemController DialogSystemController;

    private void Update()
    {
        Debug.Log(InputUserControl.action.IsPressed());
        if(InputUserControl.action.IsPressed())
            ForwardDialog();
    }

    private void ForwardDialog()
    {
        GameObject continueButtonGameObject = GameObject.Find("Continue Button");
        if(continueButtonGameObject == null)
            return;

        StandardUIContinueButtonFastForward continueButton = continueButtonGameObject.GetComponent<StandardUIContinueButtonFastForward>();
        if(continueButton == null)
            return;
        
        continueButton.OnFastForward();
    }
}
