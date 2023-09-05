using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform parentTransform;
    private float initialDelay = 3.0f;
    // private float minDelay = 0.5f;
    private float currentDelay;

    void Start()
    {
        parentTransform = transform;
        currentDelay = initialDelay;

        // 3초 후에 처음으로 함수를 호출
        Invoke("ActivateRandomChildObject", initialDelay);
    }

    // 랜덤 자식 오브젝트를 활성화하는 함수
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

        // 다음 호출을 위한 대기 시간을 줄임
        // currentDelay = Mathf.Max(currentDelay - 0.1f, minDelay);

        // 다음 호출 예약
        Invoke("ActivateRandomChildObject", currentDelay);
    }
}

