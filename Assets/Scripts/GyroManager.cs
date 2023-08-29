
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    #region Instance
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned GyroManager",typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }

            return instance;
        }
    }
    #endregion
    private Gyroscope gyro;
    private Quaternion rotation;
    private Vector3 acceleration;

    public bool gyroActive {get; private set;}

    public void EnableGyro()
    {
        if (gyroActive)
            return;
        
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
            gyro.updateInterval = 0.05f; //fps30
        }
        else
        {
            Debug.Log("Gyro is not supported on this device");
        }
    }
    
    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
            acceleration = gyro.userAcceleration;
        }
    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }

    public Vector3 GetGyroAcceleration()
    {
        return acceleration;
    }
}