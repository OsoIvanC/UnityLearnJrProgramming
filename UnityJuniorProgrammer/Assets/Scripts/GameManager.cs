using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<Shape> _shapes;

    [SerializeField]
    float _matchTime;

    [SerializeField]
    float _spawnInterval;

    [SerializeField]
    float _minX, _minY, _maxX, _maxY;

    [SerializeField]
    TextMeshProUGUI _timerText;
    [SerializeField]
    TextMeshProUGUI _colorText;
    [SerializeField]
    TextMeshProUGUI _shapeText;
    [SerializeField]
    TextMeshProUGUI _pointsText;

    [field:SerializeField] public int Points { get; set; }
    [field: SerializeField] public string ShapeChosen { get; set; }
    [field: SerializeField] public ShapeColor ShapeColor { get; set; }
    public static GameManager Instance { get; set; }

    [SerializeField]
    GameObject _gameOver;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ChooseShape();
        StartCoroutine(SpawnShape());
    }

    public void UpdatePoints()
    {
        _pointsText.SetText(Points.ToString());
    }
    void ChooseShape()
    {
        var r = Random.Range(0, _shapes.Count);

        switch (r)
        {
            case 0:
                ShapeChosen = "Triangle";
                break;
            case 1:
                ShapeChosen = "Circle";
                break;
            case 2:
                ShapeChosen = "Square";
                break;
        }

        _shapeText.SetText(ShapeChosen);

        ChooseColor();
    }

    void ChooseColor()
    {
        var r = Random.Range(0, _shapes.Count);

        switch (r)
        {
            case 0:
                ShapeColor = ShapeColor.RED;
                _colorText.color = Color.red;
                break;
            case 1:
                ShapeColor = ShapeColor.BLUE;
                _colorText.color = Color.blue;
                break;
            case 2:
                ShapeColor = ShapeColor.GREEN;
                _colorText.color = Color.green;
                break;
        }

        _colorText.SetText(ShapeColor.ToString());

    }

    public IEnumerator SpawnShape()
    {
        while (_matchTime >= 1)
        {
            var r = Random.Range(0, _shapes.Count);

            yield return new WaitForSeconds(_spawnInterval);

            Instantiate(_shapes[r], new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY)), Quaternion.identity);

            _matchTime--;

            _timerText.SetText(_matchTime.ToString());
            yield return new WaitForEndOfFrame();
        }

        _gameOver.SetActive(true);
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
