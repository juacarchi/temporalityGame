using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayButton : MonoBehaviour
{
    public string dayName;
    public string tagButton;
    public Button buttonDay;
    public BoxCollider2D box2DButton;

    public DayButton(string dayName, string tagButton, Button buttonDay, BoxCollider2D box2DButton)
    {
        this.dayName = dayName;
        this.tagButton = tagButton;
        this.buttonDay = buttonDay;
        this.box2DButton = box2DButton;
    }

}
