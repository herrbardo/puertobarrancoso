using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueEvents : MonoBehaviour
{
    private static DialogueEvents instance;

    private DialogueEvents()
    {

    }

    public static DialogueEvents GetInstance()
    {
        if(instance == null)
        {
            instance = new DialogueEvents();
            Debug.Log("INSTANCIA " + DateTime.Now.ToString());
        }
        return instance;
    }

    public delegate void ChoiceSelectedDelegate(int choiceIndex);

    public event ChoiceSelectedDelegate ChoiceSelected;

    public void OnChoiceSelected(int choiceIndex)
    {
        if(ChoiceSelected != null)
        {
            ChoiceSelected(choiceIndex);
        }
        else
            Debug.Log("NULO");
    }
}
