using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandboxManager : MonoBehaviour
{
    [SerializeField] DialogSystem DialogSystem;

    void Start()
    {
        // DialogSystem.AddDialogLine("Hola ¿Cómo estas?");
        // DialogSystem.AddChoice(0, "Bien, y vos?");
        // DialogSystem.AddChoice(1, "Cerrá el orto");
    }
}