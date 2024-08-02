using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Circle : Shape
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (GameManager.Instance.ShapeChosen == "Circle" && GameManager.Instance.ShapeColor == color)
            GameManager.Instance.Points += 3;
    }
}
