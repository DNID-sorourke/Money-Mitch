using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public AnimationCurve AccelerationCurve;
    [SerializeField] private float _timeAcceleracting;

    [SerializeField] private VirtualJoystick _joystick;
    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        if (_joystick.InputDirection.magnitude > 0)
        {
            Move();
            if (_timeAcceleracting < 1)
            {
                _timeAcceleracting += Time.deltaTime;
            }
            else
            {
                _timeAcceleracting = 1;
            }
        }
        else
        {
            _timeAcceleracting = 0;
        }
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_joystick.InputDirection.x, _joystick.InputDirection.y) 
            * MovementSpeed 
            * AccelerationCurve.Evaluate(_timeAcceleracting);
    }
}
