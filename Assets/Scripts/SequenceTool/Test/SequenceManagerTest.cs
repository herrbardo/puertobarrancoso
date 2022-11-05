using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManagerTest : MonoBehaviour
{
    [SerializeField]
    List<SequenceData> sequences;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var sequence in sequences)
        {
            //sequence.Address = "PlaceholderSequence";
            SequenceManager.Instance.AddSequence(sequence);
        }
    }

    private void Update()
    {
        
    }

}
