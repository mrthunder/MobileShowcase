using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private MovementComponent _movementComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MoveUnit(Vector3 direction)
    {
        _movementComponent.Move(direction);
    }
}
