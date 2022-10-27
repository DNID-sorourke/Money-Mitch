using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public VirtualJoystick Joystick;
    public Rigidbody2D rb;
    public AnimationCurve AccelerationCurve;
    public float accelCurveX;

    private void Update()
    {
        if (Joystick.InputDirection.magnitude > 0)
        {
            Move();
            if (accelCurveX < 1)
            {
                accelCurveX += Time.deltaTime;
            }
            else
            {
                accelCurveX = 1;
            }
        }
        else
        {
            accelCurveX = 0;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(Joystick.InputDirection.x, Joystick.InputDirection.y) 
            * MovementSpeed 
            * AccelerationCurve.Evaluate(accelCurveX);
    }
}
