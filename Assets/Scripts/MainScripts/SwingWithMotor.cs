using UnityEngine;

public class SwingWithMotor : MonoBehaviour
{
    public float maxAngle = 45f;
    public float motorSpeed = 100f;
    public float motorTorque = 1000f;

    private HingeJoint2D hinge;
    private Rigidbody2D rb;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();

        hinge.useMotor = true;
        UpdateMotorDirection();
    }

    void FixedUpdate()
    {
        float angle = rb.rotation % 360f;
        if (angle > 180f) angle -= 360f;

        if (angle >= maxAngle)
        {
            SetMotorSpeed(-Mathf.Abs(motorSpeed));
        }
        else if (angle <= -maxAngle)
        {
            SetMotorSpeed(Mathf.Abs(motorSpeed));
        }
    }

    void SetMotorSpeed(float speed)
    {
        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = speed;
        motor.maxMotorTorque = motorTorque;
        hinge.motor = motor;
    }

    void UpdateMotorDirection()
    {
        SetMotorSpeed(-Mathf.Abs(motorSpeed));
    }
}
