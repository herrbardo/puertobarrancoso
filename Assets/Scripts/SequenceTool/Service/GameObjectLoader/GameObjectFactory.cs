using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class GameObjectFactory
{
    private static readonly Dictionary<string, GameObject> _loadedPrefabs = new();
    private static readonly Dictionary<string, Sprite> _loadedSprites = new();

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
        gameObject.AddComponent<SpriteRenderer>().sprite = go;

        gameObject.SetActive(enableOnSpawn);

        if (parent)
            gameObject.transform.SetParent(parent.transform);
        return gameObject;
    }
}