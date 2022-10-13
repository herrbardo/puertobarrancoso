using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance;

    [SerializeField] Image ImageComponent;
    [SerializeField] Sprite TranceBackground;
    [SerializeField] Sprite ParkBackground;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void SetBackground(BackgroundName backgroundName)
    {
        switch(backgroundName)
        {
            case BackgroundName.TRANCE:
                ImageComponent.sprite = TranceBackground;
            break;

            case BackgroundName.PARK:
                ImageComponent.sprite = ParkBackground;
            break;
        }
    }
}
