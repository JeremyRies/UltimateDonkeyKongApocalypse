using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private string[] _options;
    [SerializeField] private float _spacing;
    [SerializeField] private float _offset;

    [Space(10)]
    [SerializeField] private GameObject _focusArrows;
    [SerializeField] private Text _textPrefab;

    private Text[] _optionTexts;
    private int _focused;

    void Start()
    {
        _optionTexts = new Text[_options.Length];
        for (int i = 0; i < _options.Length; i++)
        {
            var text = CreateTextFrom(_options[i]);
            text.transform.position = Vector3.up * getYOfPos(i);
            _optionTexts[i] = text;
        }
        UpdateFocusArrows();
    }

    private Text CreateTextFrom(string name)
    {
        var instance = Instantiate(_textPrefab, transform, false);
        instance.text = name;
        return instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            GoUpOnce();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            GoDownOnce();
    }

    private void GoUpOnce()
    {
        if (_focused <= 0) return;
        _focused--;
        UpdateFocusArrows();
    }

    private void GoDownOnce()
    {
        if (_focused >= _optionTexts.Length - 1) return;
        _focused++;
        UpdateFocusArrows();
    }

    private void UpdateFocusArrows()
    {
        _focusArrows.transform.position = Vector3.up * getYOfPos(_focused);
    }

    private float getYOfPos(int position)
    {
        if (_optionTexts.Length <= 1) return 0f;
        var topPosNorm = (_optionTexts.Length - 1) / 2f;
        var yPosNorm = topPosNorm - position;
        return yPosNorm * _spacing + _offset;
    }
}