using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBehavior : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_movementSpeed, 0);
    }

}
