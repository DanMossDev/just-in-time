using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveCount;
    [SerializeField] AudioClip[] gameOverSound;
    AudioClip[] gameOver;
    void OnEnable()
    {
        NavigationManager.Instance.ShowMouse();
        waveCount.text += GameManager.Instance.currentWave;
        SFXController.Instance.PlaySFX(gameOverSound);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
