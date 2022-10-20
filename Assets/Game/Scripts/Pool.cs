using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public delegate bool CanBeUsedCondition<T>(T element);

public abstract class BasePool<T>
{
    public abstract List<T> PooledObjects { get; protected set; }
    public abstract CanBeUsedCondition<T> CanBeUsed { get; set; }

    public virtual T Get(bool enable)
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            T o = PooledObjects[i];
            if (CanBeUsed(o))
            {
                if (enable)
                    Enable(o);

                return o;
            }
        }

        return CreateNew(enable);
    }

    protected abstract T CreateNew(bool enable);
    protected abstract void Enable(T obj);

    public abstract void DisableAll();
        
    public virtual void Clear()
    {
        PooledObjects.Clear();
    }
}

public class GameObjectPool : BasePool<GameObject>
{
    public override List<GameObject> PooledObjects { get; protected set; }
    private readonly GameObject _prefab;

    public GameObjectPool(GameObject prefab)
    {
        _prefab = prefab;
        PooledObjects = new List<GameObject>();
    }

    public override CanBeUsedCondition<GameObject> CanBeUsed { get; set; } = (o) =>
    {
        return !o.activeSelf;
    };

    public override void DisableAll()
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            PooledObjects[i].SetActive(false);
        }
    }

    protected override GameObject CreateNew(bool enable)
    {
        GameObject obj = GameObject.Instantiate(_prefab);
        PooledObjects.Add(obj);

        return obj;
    }

    public override void Clear()
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            GameObject.Destroy(PooledObjects[i]);
        }

        PooledObjects.Clear();
    }

    protected override void Enable(GameObject obj)
    {
        obj.SetActive(true);
    }
}

public class Pool<T> : BasePool<T> where T : MonoBehaviour
{
    // The prefab instantiated by this pool
    private readonly T prefab;
    private readonly Transform defaultParent;

    // The list of pooled object
    public override List<T> PooledObjects { get; protected set; } = new List<T>();

    public Pool(T prefab, Transform defaultParent = null)
    {
        this.prefab = prefab;
        this.defaultParent = defaultParent;
    }

    // The condition for a pooled object to be considered available for recycle
    public override CanBeUsedCondition<T> CanBeUsed { get; set; } = ((x) =>
    {
        return !x.gameObject.activeInHierarchy;
    });

    public override T Get(bool enableGameObject = true)
    {
        foreach (T o in PooledObjects)
        {
            if (CanBeUsed(o))
            {
                if (enableGameObject)
                {
                    o.gameObject.SetActive(true);
                }

                return o;
            }
        }

        return CreateNew(enableGameObject);
    }

    protected override void Enable(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected override T CreateNew(bool enableGameObject = true)
    {
        T newObject = MonoBehaviour.Instantiate(prefab, defaultParent, false);
        PooledObjects.Add(newObject);

        if (enableGameObject)
        {
            newObject.gameObject.SetActive(true);
        }

        return newObject;
    }

    public override void DisableAll()
    {
        foreach (T obj in PooledObjects)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public override void Clear()
    {
        foreach (var obj in PooledObjects)
        {
            MonoBehaviour.Destroy(obj.gameObject);
        }
        PooledObjects.Clear();
    }
}

