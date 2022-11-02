using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public AnimationCurve VelocityArcX;
    public AnimationCurve PositionArcY;

    private float _t;
    public float XMovementSpeed;
    public float YDistanceScalar;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        _t += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(VelocityArcX.Evaluate(_t) * XMovementSpeed, 0, 0);
        _rb.position = new Vector3(_rb.position.x, PositionArcY.Evaluate(_t) + _startPos.y * YDistanceScalar, 0);
    }
}
