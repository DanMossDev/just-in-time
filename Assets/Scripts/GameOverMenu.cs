using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveCount;
    void OnEnable()
    {
        NavigationManager.Instance.ShowMouse();
        waveCount.text += GameManager.Instance.currentWave;
    }
    public void ReturnToMenu()
    {

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
