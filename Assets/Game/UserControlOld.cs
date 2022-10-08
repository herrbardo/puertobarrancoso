using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem.Wrappers;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserControlOld : MonoBehaviour
{
    [SerializeField] float PressCooldown;
    [SerializeField] KeyCode FastForwardKey;
    [SerializeField] KeyCode UseKey;
    [SerializeField] StandardUIContinueButtonFastForward ContinueButton;

    bool enablePress;

    private void Awake()
    {
        enablePress = true;
    }

    void Update()
    {
        if(Input.GetKeyUp(FastForwardKey))
            ForwardDialog();
        else if(Input.GetKey(UseKey))
            ChooseOption();
    }

    public void ForwardDialog()
    {
        if(!enablePress)
            return;

        Forward();
        ReEnablePressSoon();
    }

    void ReEnablePressSoon()
    {
        enablePress = false;
        Invoke("EnablePressing", PressCooldown);
    }

    void EnablePressing()
    {
        enablePress = true;
    }

    void Forward()
    {
        ContinueButton.OnFastForward();
    }

    void ChooseOption()
    {
        if(!enablePress)
            return;

        Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if(button == null)
            return;
        
        StandardUIResponseButton responseButton = button.gameObject.GetComponent<StandardUIResponseButton>();
        if(responseButton == null)
            return;

        responseButton.OnClick();
        ReEnablePressSoon();
    }
}
