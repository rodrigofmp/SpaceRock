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


        if (this.Points % 1000 == 0)
        { 
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().IncreaseShootFrequency();
            GameObject.Find("MeteorCreator").GetComponent<MeteorCreator>().IncreaseMeteorSpeed();
        }
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
