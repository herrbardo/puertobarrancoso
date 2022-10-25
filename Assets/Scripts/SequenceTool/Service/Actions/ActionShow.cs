using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionShow : Action
{
    SpriteRenderer spriteRenderer;
    ActionShowData data;
    public ActionShow(ActionShowData data) : base(data)
    {
        this.data = data;
        IsDone = Completed = false;
        
    }

    

    public override async Task Execute()
    {
        IsDone = Completed = false;
        Vector3 pos = new Vector3(data.position.x, data.position.y, 0);
        var go = await GameObjectFactory.InstantiateSpriteRenderer(data.objectAddress, pos, Quaternion.identity, null, false);
        spriteRenderer = go.GetComponent<SpriteRenderer>();
        {
            spriteRenderer.sortingLayerName = data.layer;
            spriteRenderer.sortingOrder = data.orderInLayer;
        }
        IsDone = true;
        if(data.transition == Transition.FadeIn)
        {
            float t = 0;
            Color color = spriteRenderer.color;
            color.a = 0;
            spriteRenderer.color = color;
            spriteRenderer.gameObject.SetActive(true);
            float invTime = 1 / data.time;
            while (t < data.time)
            {
                spriteRenderer.color = color;
                await Task.Delay(10);
                t += 0.01f;
                color.a = Mathf.Lerp(0, 1, t * invTime);

            }
        }
        else
        {
            spriteRenderer.gameObject.SetActive(true);
        }
        Completed = true;
    }
}
