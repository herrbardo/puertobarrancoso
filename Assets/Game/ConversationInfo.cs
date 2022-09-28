using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationInfo
{
    public string Title { get; set; }
    public Transform Actor { get; set; }
    public Transform Conversant { get; set; }

    public static bool operator == (ConversationInfo a, ConversationInfo b)
    {
        return a.Actor.Equals(b.Actor);
    }

    public static bool operator != (ConversationInfo a, ConversationInfo b)
    {
        return !a.Actor.Equals(b.Actor);
    }
}
