using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public AnimationCurve VelocityArcX;
    public AnimationCurve PositionArcY;

    public float t;
    public float XMovementSpeed;
    public float YDistanceScalar;

    [SerializeField] private Rigidbody _rb;

    void Update()
    {
        t += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(VelocityArcX.Evaluate(t) * XMovementSpeed, 0, 0);
        _rb.position = new Vector3(_rb.position.x, PositionArcY.Evaluate(t) * YDistanceScalar, 0);
    }
}
