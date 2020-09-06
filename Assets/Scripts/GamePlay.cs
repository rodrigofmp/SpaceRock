using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public Button RestartButton;
    public Text PointText;
    public int Points = 0;

    public void AddPoints()
    {
        this.Points += 100;
        this.PointText.text = this.Points.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowRestartButton()
    {
        this.RestartButton.gameObject.SetActive(true);
    }
}
