using UnityEngine;

public class SwingController : MonoBehaviour
{
    public Rigidbody2D ropeRb;
    public HingeJoint2D hinge;
    public float swingTorque = 50f;
    public float angleThreshold = 1f;
    public float startPush = 50f;

    private float minAngle, maxAngle;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        ropeRb = GetComponent<Rigidbody2D>();
        minAngle = hinge.limits.min;
        maxAngle = hinge.limits.max;

        //เริ่มแกว่งตั้งแต่เริ่มเกม
        ropeRb.AddTorque(startPush, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        float angle = hinge.jointAngle;

        if (Mathf.Abs(angle - maxAngle) < angleThreshold)
        {
            ropeRb.AddTorque(-swingTorque);
        }
        else if (Mathf.Abs(angle - minAngle) < angleThreshold)
        {
            ropeRb.AddTorque(swingTorque);
        }
    }
}
