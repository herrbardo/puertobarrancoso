using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionShow : Action
{
    ActionShowData data;
    public ActionShow(ActionShowData data) : base(data)
    {
        this.data = data;
        IsDone = Completed = false;
        
    }

    

    public override async Task Execute(Sequence seq)
    {
        IsDone = Completed = false;
        Vector3 pos = new Vector3(data.position.x, data.position.y, 0);
        GameObject go = null;
        if(data.PrefabType == PrefabType.Sprite)
            go = await GameObjectFactory.InstantiateSpriteRenderer(data.objectAddress, pos, Quaternion.identity, null, false);
        else
            go = await GameObjectFactory.InstantiateGameObject(data.objectAddress, pos, Quaternion.identity, null, false);
        
        if (!go) return;
        go.name = data.ObjectAddress;
        seq.AddGameObject(data.ObjectAddress, go);

        SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
        {
            spriteRenderer.sortingLayerName = data.layer;
            spriteRenderer.sortingOrder = data.orderInLayer;
        }
        IsDone = true;
        if(data.transition == TransitionIn.FadeIn)
        {
            float t = 0;
            Color color = spriteRenderer.color;
            float a = color.a;
            color.a = 0;
            spriteRenderer.color = color;
            spriteRenderer.gameObject.SetActive(true);
            float invTime = 1 / data.time;
            while (t < data.time)
            {
                spriteRenderer.color = color;
                await Task.Delay(10);
                t += 0.01f;
                color = spriteRenderer.color;
                color.a = Mathf.Lerp(0, a, t * invTime);

            }
        }
        else
        {
            spriteRenderer.gameObject.SetActive(true);
        }
        Completed = true;
    }
}
