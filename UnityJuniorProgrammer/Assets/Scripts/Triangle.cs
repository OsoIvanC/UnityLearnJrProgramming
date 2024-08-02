using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//INHERTIANCE
public class Triangle : Shape
{
    //POLYMORPHISM
   public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (GameManager.Instance.ShapeChosen == "Triangle" && GameManager.Instance.ShapeColor == color)
            GameManager.Instance.Points += 3;
    }
}
