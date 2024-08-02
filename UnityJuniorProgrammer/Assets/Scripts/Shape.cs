using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ShapeColor
{
    RED = 1, 
    GREEN, 
    BLUE,
}
public class Shape : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    protected ShapeColor color;

    [SerializeField]
    protected float _shrinkSpeed;

    private void Awake()
    {
        SetRandomColor();
    }

    //ABSTRACTION
    public void SetRandomColor()
    {
        var i = Random.Range(1, 4);

        color = (ShapeColor)i;

        Debug.Log(i);
        switch((ShapeColor)i)
        {
            case ShapeColor.RED:
                GetComponent<SpriteRenderer>().color = Color.red;
                
                break;
            case ShapeColor.GREEN:

                GetComponent<SpriteRenderer>().color = Color.green;
                break; 
            case ShapeColor.BLUE:

                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        Shrink();
    }

    public  void Shrink()
    {
        if (transform.localScale.magnitude >= 0.1f)
            transform.localScale -= Vector3.one * _shrinkSpeed * Time.deltaTime;
        else
            gameObject.SetActive(false);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.ShapeColor == color)
            GameManager.Instance.Points += 1;
        else
            GameManager.Instance.Points -= 1;
        
        GameManager.Instance.UpdatePoints();
        gameObject.SetActive(false);
    }

}
