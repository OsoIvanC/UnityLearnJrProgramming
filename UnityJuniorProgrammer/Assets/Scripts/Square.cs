using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Square : Shape
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (GameManager.Instance.ShapeChosen == "Square" && GameManager.Instance.ShapeColor == color)
            GameManager.Instance.Points += 3;
    }
}
