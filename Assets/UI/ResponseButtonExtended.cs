using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResponseButtonExtended : MonoBehaviour
{
    [SerializeField] Button MyButton;
    [SerializeField] Color SelectedColor;
    [SerializeField] Color NormalColor;
    [SerializeField] Text Text;

    private void Update()
    {
        CheckForSelected();
    }

    void CheckForSelected()
    {
        GameObject gameObject = EventSystem.current.currentSelectedGameObject;
        if(gameObject == null)
            return;

        Button selectedButton = gameObject.GetComponent<Button>();
        if(selectedButton == null)
            return;
        
        if(MyButton.name == selectedButton.name)
            Text.color = SelectedColor;
        else
            Text.color = NormalColor;
    }
}
