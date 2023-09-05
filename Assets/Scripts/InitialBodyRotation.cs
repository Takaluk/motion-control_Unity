using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialBodyRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float value = PlayerPrefs.GetFloat("UserBodyTransform",0);
        transform.rotation = Quaternion.Euler(90f, value, 0f);
    }
}
