using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;


public static class GameObjectFactory
{
    private static readonly Dictionary<string, GameObject> _loadedPrefabs = new();
    private static readonly Dictionary<string, GameObjectPool> _pool = new();

    public static async Task<GameObject> InstantiateGameObject(string prefabName, Vector3 position = default, Quaternion rotationbool = default, bool enableOnSpawn = true)
    {            
        if (_loadedPrefabs.TryGetValue(prefabName, out var go) == false)
        {
            var load = Addressables.LoadAssetAsync<GameObject>(prefabName);
            await load.Task;

            go = load.Result;

            _loadedPrefabs.Add(prefabName, go);
        }

        if (!_pool.TryGetValue(prefabName, out var pool))
        {
            pool = new GameObjectPool(go);
            _pool.Add(prefabName, pool);
        }

        var gameObject = pool.Get(enableOnSpawn);

        return gameObject;
    }
}
