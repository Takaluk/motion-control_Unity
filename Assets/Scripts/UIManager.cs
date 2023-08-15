using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform sliceableParentTransform;
    public Transform hullParentTransform;

    public void ResetObjects()
    {

        for (int i = 0; i < hullParentTransform.childCount; i++)
        {
            // 각 자식 오브젝트를 가져옵니다.
            Transform childTransform = hullParentTransform.GetChild(i);
            Destroy(childTransform.gameObject);
        }
        // 부모 오브젝트의 모든 자식 오브젝트를 검색합니다.
        for (int i = 0; i < sliceableParentTransform.childCount; i++)
        {
            // 각 자식 오브젝트를 가져옵니다.
            Transform childTransform = sliceableParentTransform.GetChild(i);

            // 자식 오브젝트가 비활성화되어 있다면 활성화시킵니다.
            if (!childTransform.gameObject.activeSelf)
            {
                childTransform.gameObject.SetActive(true);
            }
        }
    }
}
