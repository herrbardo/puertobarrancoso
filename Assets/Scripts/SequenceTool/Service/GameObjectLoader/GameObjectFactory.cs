using PixelCrushers.DialogueSystem.Wrappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class GameObjectFactory
{
    private static readonly Dictionary<string, GameObject> _loadedPrefabs = new();
    private static readonly Dictionary<string, Sprite> _loadedSprites = new();
    private static readonly Dictionary<string, SequenceData> _loadedSequences = new();
    private static readonly Dictionary<string, DialogueDatabase> _loadedDialogues = new();

    public static async Task<GameObject> InstantiateGameObject(string prefabName, Vector3 position = default, Quaternion rotation = default, GameObject parent = null, bool enableOnSpawn = true)
    {
        if (_loadedPrefabs.TryGetValue(prefabName, out var go) == false)
        {
            var load = Addressables.LoadAssetAsync<GameObject>(prefabName);
            await load.Task;

            go = load.Result;

            _loadedPrefabs.Add(prefabName, go);
        }


        var gameObject = GameObject.Instantiate(go, position, rotation);
        gameObject.name = prefabName;
        gameObject.transform.position = position;

        gameObject.SetActive(enableOnSpawn);

        if(parent)
            gameObject.transform.SetParent(parent.transform);
        return gameObject;
    }

    public static async Task<GameObject> InstantiateSpriteRenderer(string prefabName, Vector3 position = default, Quaternion rotation = default, GameObject parent = null, bool enableOnSpawn = true)
    {
        if (_loadedSprites.TryGetValue(prefabName, out var go) == false)
        {
            var load = Addressables.LoadAssetAsync<Sprite>(prefabName);
            await load.Task;

            

            go = load.Result;

            _loadedSprites.Add(prefabName, go);
        }


        var gameObject = new GameObject();
        gameObject.name = prefabName;
        gameObject.AddComponent<SpriteRenderer>().sprite = go;
        gameObject.transform.position = position;
        gameObject.SetActive(enableOnSpawn);

        if (parent)
            gameObject.transform.SetParent(parent.transform);
        return gameObject;
    }

    public static async Task<SequenceData> LoadSequence(string sequenceAddress)
    {
        if (_loadedSequences.TryGetValue(sequenceAddress, out var sequence) == false)
        {
            var load = Addressables.LoadAssetAsync<SequenceData>(sequenceAddress);
            await load.Task;

            sequence = load.Result;

            _loadedSequences.Add(sequenceAddress, sequence);
        }

        return sequence;

    }

    public static async Task<DialogueDatabase> LoadDialogue(string dialogueAddress)
    {
        if (_loadedDialogues.TryGetValue(dialogueAddress, out var dialogue) == false)
        {
            var load = Addressables.LoadAssetAsync<DialogueDatabase>(dialogueAddress);
            await load.Task;

            dialogue = load.Result;

            _loadedDialogues.Add(dialogueAddress, dialogue);
        }

        return dialogue;
    }
}