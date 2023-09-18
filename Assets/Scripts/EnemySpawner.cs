using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform parentTransform;
    private float initialDelay = 2.5f;
    public float minDelay = 0.5f;
    private float currentDelay;

    void Start()
    {
        parentTransform = transform;
        currentDelay = initialDelay;
        Invoke("ActivateRandomChildObject", initialDelay);
    }

    void ActivateRandomChildObject()
    {
        Transform[] childObjects = parentTransform.GetComponentsInChildren<Transform>(true);
        List<Transform> inactiveChildren = new List<Transform>();

        foreach (Transform child in childObjects)
        {
            if (child != parentTransform && !child.gameObject.activeSelf)
            {
                inactiveChildren.Add(child);
            }
        }

        if (inactiveChildren.Count > 0)
        {
            int randomIndex = Random.Range(0, inactiveChildren.Count);
            inactiveChildren[randomIndex].gameObject.SetActive(true);
        }

        currentDelay = Mathf.Max(currentDelay - 0.1f, minDelay);
        Invoke("ActivateRandomChildObject", currentDelay);
    }
}

