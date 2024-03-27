using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialoguePopUp : MonoBehaviour
{
    [SerializeField] private Image _character;
    [SerializeField] private Text _text;
    [SerializeField] private Image _window;
    [SerializeField] private string _targetText;
    [SerializeField] private UnityEvent _onComplete;

    private Tween _textTween;

    public void Show()
    {
        BounceAnimation bounceAnimation = new BounceAnimation(_character.transform);
        bounceAnimation.Play(0.2f);
        BounceAnimation bounceAnimation1 = new BounceAnimation(_window.transform);
        bounceAnimation1.Play(0.2f);

        _textTween = _text.DOText(_targetText, 2);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_textTween.IsComplete() == false && _textTween.IsActive())
            {
                _textTween.Complete();
                return;
            }
            else
            {
                _onComplete?.Invoke();
            }
        }
    }
}
