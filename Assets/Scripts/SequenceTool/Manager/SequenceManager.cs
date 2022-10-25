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

    public List<IEnumerator> tasks = new List<IEnumerator>();

    protected List<Sequence> sequences = new List<Sequence>();

    public void AddSequence(SequenceData seq)
    {
        sequences.Add(new Sequence(seq));
    }

    public void Update()
    {
        foreach(var sequence in sequences)
        {
            var task = sequence.Execute();
            tasks.Add(task);
        }
        sequences.Clear();

        int i = 0;
        while(i<tasks.Count)
        {
            var task = tasks[i];
            if (!task.MoveNext())
            {
                tasks.Remove(task);
            }
            else i++;

        }
    }



}
