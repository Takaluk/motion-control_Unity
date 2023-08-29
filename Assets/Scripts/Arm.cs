using UnityEngine;

public class Arm : MonoBehaviour
{
    public SliceObject sliceObject;
    public float swingThreshold = 1.0f;
    public float swingTerm = 0.5f;
    private float lastSwingTime = 0f;

    private void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    private void FixedUpdate() 
    {
        transform.localRotation = GyroManager.Instance.GetGyroRotation();

        if (Time.time - lastSwingTime > swingTerm)
        {
            if (GyroManager.Instance.GetGyroAcceleration().x > swingThreshold)
            {
                lastSwingTime = Time.time;
            }
        }
        else
        {
            sliceObject.ObejctSlice();
        }
    }
}
