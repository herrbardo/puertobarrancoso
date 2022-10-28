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

    public class SequencerCommandContinue : SequencerCommand
    {
        void Start()
        {

            SequenceManager.Instance.Continue();
            Stop();
        }
    }
}
