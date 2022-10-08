using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blink : MonoBehaviour
{
    public void BlinkMe()
    {
        Debug.Log("Blink " + DateTime.Now);
    }
}
