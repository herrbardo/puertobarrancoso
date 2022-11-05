using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionHide : Action
{
    ActionHideData data;
    public ActionHide(ActionHideData data) : base(data)
    {
        this.data = data;
    }

    public override async Task Execute(Sequence seq)
    {
        Debug.Log("Action: Hide object " + data.objectAddress);
        var go = seq.GetGameObject(data.ObjectAddress);
        if (go == null)
        {
            Debug.LogError("wrong object address");
            return;
        }

        SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
        
        IsDone = true;
        if (data.transition == TransitionOut.FadeOut)
        {
            float t = 0;
            Color color = spriteRenderer.color;
            float a = color.a;
            spriteRenderer.gameObject.SetActive(true);
            float invTime = 1 / data.time;
            while (t < data.time)
            {
                spriteRenderer.color = color;
                await Task.Delay(10);
                t += 0.01f;
                color = spriteRenderer.color;
                color.a = Mathf.Lerp(a, 0, t * invTime);

            }
        }
        spriteRenderer.gameObject.SetActive(false);
        seq.RemoveGameObject(data.ObjectAddress);
        Completed = true;

    }
}