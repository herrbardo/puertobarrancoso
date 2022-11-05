using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
    public class SequencerCommandSetBackground : SequencerCommand
    {
        void Start()
        {
            string backgroundName = GetParameter(0);
            BackgroundName name = Utilities.ParseEnum<BackgroundName>(backgroundName);
            BackgroundManager.Instance.SetBackground(name);
            Stop();
        }
        
    }

    public class SequencerCommandContinueSequence : SequencerCommand
    {

        void Start()
        {
            var arg = GetParameter(0);
            Debug.Log(arg);
            SequenceManager.Instance.Continue();
            Stop();
        }
    }
}
