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

    public Dictionary<string, Sequence> currentSequences = new Dictionary<string, Sequence>();

    protected List<Sequence> sequences = new List<Sequence>();
    public List<string> keys = new List<string>();

    public void AddSequence(SequenceData seq)
    {
        Debug.Log("Added sequence " + seq.Address);
        sequences.Add(new Sequence(seq));
    }

    public void Update()
    {
        foreach(var sequence in sequences)
        {
            currentSequences.Add(sequence.Data.Address, sequence);
            keys.Add(sequence.Data.Address);
        }
        if(sequences.Count > 0)
            sequences.Clear();

        int i = 0;
        while(i < keys.Count)
        {
            var sequence = currentSequences[keys[i]];
            if (!sequence.Task.MoveNext() || sequence.Finished)
            {
                currentSequences.Remove(keys[i]);
                keys.Remove(sequence.Data.Address);
            }
            else i++;

        }
    }

    public void Continue(string address)
    {
        var sequence = currentSequences[address];
        sequence.Continue();
    }


}
