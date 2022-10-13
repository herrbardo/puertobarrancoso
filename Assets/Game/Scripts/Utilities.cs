using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Utilities
{
    public static List<GameObject> GetChildrens(GameObject parent)
    {
        List<GameObject> childrens = new List<GameObject>();
        foreach (Transform item in parent.transform)
            childrens.Add(item.gameObject);        

        return childrens;
    }

    public static GameObject Find(string name, GameObject parent)
    {
        List<GameObject> childrens = GetChildrens(parent);
        foreach (GameObject children in childrens)
        {
            if(children.name.Equals(name))
                return children;
            else
                return Find(name, children);
        }

        return null;
    }

    public static T ParseEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }
}
