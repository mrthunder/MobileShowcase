using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Unit Player;
    public MobileJoystick Joystick;
    // Start is called before the first frame update
    void Start()
    {
        Joystick.OnChange.AddListener(MovePlayer);
    }


    public void MovePlayer(Vector2 direction)
    {
        Vector3 relativeDirection = new Vector3(direction.x, 0, direction.y);
        Player.MoveUnit(relativeDirection);
    }
}
