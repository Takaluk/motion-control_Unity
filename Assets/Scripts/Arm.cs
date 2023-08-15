using UnityEngine;

public class Arm : MonoBehaviour
{
    public SwordController swordController;

    private void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    private void FixedUpdate() 
    {
        transform.localRotation = GyroManager.Instance.GetGyroRotation();
        swordController.Swing();
    }
}
