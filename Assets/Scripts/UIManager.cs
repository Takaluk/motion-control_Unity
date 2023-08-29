using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public Transform sliceableParentTransform;
    public Transform hullParentTransform;
    public Transform bodyTransform;
    public void OnResetButton()
    {

        for (int i = 0; i < hullParentTransform.childCount; i++)
        {
            Transform childTransform = hullParentTransform.GetChild(i);
            Destroy(childTransform.gameObject);
        }
        for (int i = 0; i < sliceableParentTransform.childCount; i++)
        {
            Transform childTransform = sliceableParentTransform.GetChild(i);

            if (!childTransform.gameObject.activeSelf)
            {
                childTransform.gameObject.SetActive(true);
            }
        }
    }

    public void OnSliderEvent(float value)
    {
        bodyTransform.rotation = Quaternion.Euler(90f, value, 0f);
    }
}
