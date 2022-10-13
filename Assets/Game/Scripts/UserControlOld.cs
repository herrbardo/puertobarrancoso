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

    StandardUIContinueButtonFastForward _continueButton;
    bool _enablePress;

    private void Awake()
    {
        _enablePress = true;
    }

    void Update()
    {
        if(Input.GetKeyUp(FastForwardKey))
            ForwardDialog();
        else if(Input.GetKey(UseKey))
            ChooseOption();
    }

    void FindObjects()
    {
        GameObject dialogController = GameObject.Find("Dialogue Manager");
        if(dialogController == null)
            return;
        
        GameObject continueButtonGameObject = Utilities.Find("Continue Button", dialogController);
        if(continueButtonGameObject)
            Debug.Log("PUITA");
        else
            Debug.Log("NULL-O");
    }

    public void ForwardDialog()
    {
        if(!_enablePress)
            return;

        GameObject go = GameObject.Find("Continue Button");
        if(go != null)
        {
            _continueButton = go.GetComponent<StandardUIContinueButtonFastForward>();
            if(_continueButton != null)
                Forward();
        }

        ReEnablePressSoon();
    }

    void ReEnablePressSoon()
    {
        _enablePress = false;
        Invoke("EnablePressing", PressCooldown);
    }

    void EnablePressing()
    {
        _enablePress = true;
    }

    void Forward()
    {
        _continueButton.OnFastForward();
    }

    void ChooseOption()
    {
        if(!_enablePress)
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
