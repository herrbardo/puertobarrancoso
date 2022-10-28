using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SequenceManager: MonoBehaviour
{
    public static SequenceManager _instance;
    public static SequenceManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<SequenceManager>();
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public List<Sequence> currentSequences = new List<Sequence>();

    protected List<Sequence> sequences = new List<Sequence>();

    public void AddSequence(SequenceData seq)
    {
        sequences.Add(new Sequence(seq));
    }

    public void Update()
    {
        foreach(var sequence in sequences)
        {
            currentSequences.Add(sequence);
        }
        if(sequences.Count > 0)
            sequences.Clear();

        int i = 0;
        while(i < currentSequences.Count)
        {
            var sequence = currentSequences[i];
            if (!sequence.Task.MoveNext() || sequence.Finished)
            {
                currentSequences.Remove(sequence);
            }
            else i++;

        }
    }

    public void Continue()
    {
        foreach(var sequence in currentSequences)
        {
            sequence.Continue();
        }
    }


}
