using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class StoryMetadata
{
    public NodeType Type { get; set; }
    public string Speaker { get; set; }

    public StoryMetadata(Story story)
    {
        Type = NodeType.TEXT;
        ReadTags(story);
    }

    void ReadTags(Story story)
    {
        foreach (string currentTag in story.currentTags)
        {
            string[] array = currentTag.Split(":");
            string name = array[0].ToLower();
            string value = array[1];

            if(name.Equals(Tags.TYPE.ToString().ToLower()))
                Type = Enum.Parse<NodeType>(value);
            else if(name.Equals(Tags.SPEAKER.ToString().ToLower()))
                Speaker = value;
        }
    }
}
