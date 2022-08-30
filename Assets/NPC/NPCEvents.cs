using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void NPCSelectedDelegate(string name);

public class NPCEvents
{
    private static NPCEvents instance;

    private NPCEvents()
    {

    }

    public static NPCEvents GetInstance()
    {
        if(instance == null)
            instance = new NPCEvents();
        return instance;
    }

    public event NPCSelectedDelegate NPCSelected;

    public void OnNPCSelected(string name)
    {
        if(NPCSelected != null)
            NPCSelected(name);
    }
}
