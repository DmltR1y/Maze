using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f; // Время в секундах
    public TextMeshProUGUI countdownText; // UI текст для отображения времени

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            countdownText.text = "Время: " + Mathf.Round(timeLeft).ToString();
            DataTransfer.TimeLeft = timeLeft;
        }
        else
        {
            SceneManager.LoadScene("Menu");
            // Действия после окончания отсчета
        }
    }
}
