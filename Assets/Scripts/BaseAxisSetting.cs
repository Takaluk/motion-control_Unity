
using UnityEngine;
using UnityEngine.UI;

public class BaseAxisSetting : MonoBehaviour
{

    public Slider rotationSlider; // Inspector에서 UI Slider를 연결할 변수

    private void Start()
    {
        // Slider의 값이 변경될 때마다 OnSliderValueChanged 메서드를 호출하도록 연결
        rotationSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        // UI Slider의 값에 따라 오브젝트의 회전을 조절
        float rotationValue = value; // UI Slider의 값은 0에서 1 사이이므로 회전 값으로 변환
        transform.rotation = Quaternion.Euler(90f, rotationValue, 0f);
    }
}
