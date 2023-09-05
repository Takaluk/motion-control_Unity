using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button menuButton;
    public Button camButton;
    public GameObject buttonPanel;

    public Transform sliceableParentTransform;
    public Transform hullParentTransform;
    public Transform bodyTransform;

    public Camera cam1;
    public Camera cam2;

    private Camera AcitveCam;
    private Image MenuButtonImage;
    private Image CamButtonImage;

    private void Start() {
        AcitveCam = cam1;
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);

        MenuButtonImage = menuButton.GetComponent<Image>();
        CamButtonImage = camButton.GetComponent<Image>();
    }

    public void OnMenuButton()
    {
        if (buttonPanel.activeSelf)
        {
            buttonPanel.SetActive(false);

            MenuButtonImage.color = Color.white;
        }
        else
        {
            buttonPanel.SetActive(true);

            MenuButtonImage.color = Color.black;
        }
    }

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

    public void OnCamButton()
    {
        if (AcitveCam == cam1)
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
            AcitveCam = cam2;

            CamButtonImage.color = Color.black;
        }
        else
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
            AcitveCam = cam1;

            CamButtonImage.color = Color.white;
        }
    }

    public void OnSliderEvent(float value)
    {
        bodyTransform.rotation = Quaternion.Euler(90f, value, 0f);
    }

    public void OnSurviveButton()
    {
        PlayerPrefs.SetFloat("UserBodyTransform", bodyTransform.rotation.eulerAngles.y);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Survive");
    }
}
