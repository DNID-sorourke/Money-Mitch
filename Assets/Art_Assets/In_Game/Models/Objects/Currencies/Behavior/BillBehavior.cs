using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBehavior : MonoBehaviour
{
    public AnimationCurve VelocityCurve;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Rigidbody _rb;
    private float t;

    private void FixedUpdate()
    {
        t += Time.deltaTime;
        _rb.velocity = new Vector2(VelocityCurve.Evaluate(t) * _movementSpeed, 0);
    }

}
