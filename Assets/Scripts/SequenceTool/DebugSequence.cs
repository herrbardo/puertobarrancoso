using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugSequence : MonoBehaviour
{
    public static DebugSequence Instance;
    [SerializeField] TextMeshProUGUI textUI;

    private void Awake()
    {
        Instance = this;
    }
    public void SetText(string text)
    {
        textUI.text = text;
    }

    private void Update()
    {
        if (SequenceManager.Instance.currentSequences.Count > 0)
            SetText("Action: " + (SequenceManager.Instance.currentSequences[SequenceManager.Instance.keys[0]].ActionIndex - 1));
    }

}
