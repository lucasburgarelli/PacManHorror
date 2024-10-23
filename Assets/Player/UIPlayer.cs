using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPoints, textLifesLeft;
    [SerializeField] private List<GameObject> _skulls;
    [SerializeField] private AudioSource _deadSound, _victorySound;
    public GameObject menuPause, menuVictory, menuDead, menuLost;

    private float _time;

    public void SetPointsText(int points)
    {
        textMeshPoints.SetText(points + " Points Left");
    }

    public void SetPositionText(bool isMapAllowed)
    {
        var positionNew = textMeshPoints.rectTransform.position;
        // positionNew.y = isMapAllowed ? -35 : -200;
        // TODO Correct change text position on Y axis
        textMeshPoints.rectTransform.position = positionNew;
    }

    public void ShowVictoryMenu()
    {
        _victorySound.Play();
        menuVictory.SetActive(true);
        SetPausing(true);
    }
    public void ShowLostMenu()
    {
        menuLost.SetActive(true);
        SetPausing(true);
    }

    public void StartDeadMenuAnimation(int skullsLeft)
    {
        StartCoroutine(StartDeadAnimatio(skullsLeft));
    }
    
    private IEnumerator StartDeadAnimatio(int skullsLeft)
    {
        menuDead.SetActive(true);
        SetPausing(true);
        yield return new WaitForSecondsRealtime(2.5f);
        ChangeSkullActive(skullsLeft);
        yield return new WaitForSecondsRealtime(2.5f);
        SetPausing(false);
        menuDead.SetActive(false);
    }

    private void SetPausing(bool isPausing)
    {
        Cursor.visible = isPausing;
        Time.timeScale = isPausing ? 0 : 1;
    }

    private void ChangeSkullActive(int skullsLeft)
    {
        var count = 0;
        _skulls.ForEach(skull =>
        {
            count++;
            if (count <= skullsLeft) return;
            skull.SetActive(false);
        });
        textLifesLeft.SetText($"{skullsLeft} lifes left");
        _deadSound.Play();
    }
}
