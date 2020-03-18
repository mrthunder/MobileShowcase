using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileJoystickView : MonoBehaviour
{
    [SerializeField]
    private Image _backgroundImage;
    [SerializeField]
    private Image _buttonImage;

    private void Start()
    {
        _backgroundImage.enabled = false;
        _buttonImage.enabled = false;
    }

    public void Show()
    {
        _backgroundImage.enabled = true;
        _buttonImage.enabled = true;
    }

    public void Hide()
    {
        _backgroundImage.enabled = false;
        _buttonImage.enabled = false;
    }

    public void MoveButtonImage(Vector2 start,Vector2 delta, float movementRange)
    {
        /*RectTransformUtility.ScreenPointToLocalPointInRectangle(_backgroundImage.rectTransform, start, Camera.main, out Vector2 localStart);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_backgroundImage.rectTransform, delta, Camera.main, out Vector2 localDelta);*/
        _buttonImage.rectTransform.localPosition = delta*movementRange;
        _backgroundImage.rectTransform.position = start;
    }

}
