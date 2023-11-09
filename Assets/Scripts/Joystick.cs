using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _backgroundField;
    [SerializeField] private Image _handle;


    private Vector2 _joystickStartPosition;

    protected Vector2 _inputVector;

    public void Initialize()
    {
        _joystickStartPosition = _backgroundField.rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_backgroundField.rectTransform, eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = joystickPosition.x * 2 / _backgroundField.rectTransform.sizeDelta.x;
            joystickPosition.y = joystickPosition.y * 2 / _backgroundField.rectTransform.sizeDelta.y;

            _inputVector = new Vector2(joystickPosition.x, joystickPosition.y);

            _inputVector = _inputVector.magnitude > 1f ? _inputVector.normalized : _inputVector;

            _handle.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_backgroundField.rectTransform.sizeDelta.x / 2), _inputVector.y * (_backgroundField.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 joystickBackgroundPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystick.rectTransform, eventData.position, null, out joystickBackgroundPosition))
        {
            _backgroundField.rectTransform.anchoredPosition = new Vector2(joystickBackgroundPosition.x, joystickBackgroundPosition.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _backgroundField.rectTransform.anchoredPosition = _joystickStartPosition;
        _inputVector = Vector2.zero;
        _handle.rectTransform.anchoredPosition = Vector2.zero;
    }
}
