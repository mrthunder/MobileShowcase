using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Vector2Event : UnityEvent<Vector2> { }

public class MobileJoystick : MonoBehaviour
{
    private Vector2 _startPosition = Vector2.zero;
    private Vector2 _endPosition = Vector2.zero;
    private float _maxDistance = 50;

    private bool _didMove = false;

    public Vector2Event OnChange;

    public MobileJoystickView View = null;

    // Update is called once per frame
    void Update()
    {
        foreach (var touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.position;
                if (View)
                {
                    View.Show();
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                _endPosition = _endPosition+touch.deltaPosition;
                Vector2 value = GetAxisValue(_endPosition);
                OnChange.Invoke(value);
                _didMove = true;
                if(View)
                {
                    View.MoveButtonImage(_startPosition, value, _maxDistance);
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                if(_didMove)
                {
                    _didMove = false;
                    // call function
                    _startPosition = Vector2.zero;
                    _endPosition = Vector2.zero;
                    OnChange.Invoke(Vector2.zero);
                    if (View)
                    {
                        View.MoveButtonImage(Vector2.zero, Vector2.zero,_maxDistance);
                        View.Hide();
                    }
                }
            }
        }
    }

    private void OnDestroy() => OnChange.RemoveAllListeners();


    Vector2 GetAxisValue(Vector2 delta)
    {
        float correctedDistanceX = Mathf.Clamp(delta.x, -_maxDistance, _maxDistance);
        int signalX = correctedDistanceX < 0?-1:1;
        float correctedDistanceY = Mathf.Clamp(delta.y, -_maxDistance, _maxDistance);
        int signalY = correctedDistanceY < 0 ? -1 : 1;
        return new Vector2(Mathf.InverseLerp(0, _maxDistance, Mathf.Abs(correctedDistanceX))*signalX, Mathf.InverseLerp(0, _maxDistance, Mathf.Abs(correctedDistanceY))*signalY);
    }
}
