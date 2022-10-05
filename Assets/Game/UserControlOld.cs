using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem.Wrappers;
using System;

public class UserControlOld : MonoBehaviour
{
    [SerializeField] float PressCooldown;
    [SerializeField] KeyCode FastForwardKey;

    bool enablePress;

    private void Awake()
    {
        enablePress = true;
    }

    void Update()
    {
        if(Input.GetKeyUp(FastForwardKey))
            ForwardDialog();
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
        GameObject continueButtonGameObject = GameObject.Find("Continue Button");
        if(continueButtonGameObject == null)
            return;

        StandardUIContinueButtonFastForward continueButton = continueButtonGameObject.GetComponent<StandardUIContinueButtonFastForward>();
        if(continueButton == null)
            return;
        
        continueButton.OnFastForward();
        Debug.Log("HEMOS FORDEADO " + DateTime.Now);
    }
}
