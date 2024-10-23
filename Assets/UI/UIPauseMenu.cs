using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void OnButtonContinueClick()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void OnSliderValueChanged()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().ChangeSensibility(slider.value);
    }
}
