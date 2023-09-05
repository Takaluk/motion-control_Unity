using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSurvive : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public LayerMask enemyLayer;

    public float swingThreshold = 1.0f;
    public float swingTerm = 0.5f;
    private float lastSwingTime = 0f;
    private bool onAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        transform.localRotation = GyroManager.Instance.GetGyroRotation();

        if (Time.time - lastSwingTime > swingTerm)
        {
            if (GyroManager.Instance.GetGyroAcceleration().x > swingThreshold)
            {
                lastSwingTime = Time.time;
                onAttack = true;
            }
        }
        else
        {
            if (onAttack)
            {
                bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, enemyLayer);
                if (hasHit)
                {
                    onAttack = false;
                    
                    EnemyHitPoints target = hit.collider.GetComponent<EnemyHitPoints>();

                    if (target != null)
                    {
                        if (target.EnemyArrived)
                        {
                            target.Die();
                        }
                        //else에 허공베는소리 추가
                    }
                }
            }
        }
    }
}
