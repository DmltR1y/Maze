using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f; // ����� � ��������
    public TextMeshProUGUI countdownText; // UI ����� ��� ����������� �������

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            countdownText.text = "�����: " + Mathf.Round(timeLeft).ToString();
            DataTransfer.TimeLeft = timeLeft;
        }
        else
        {
            SceneManager.LoadScene("Menu");
            // �������� ����� ��������� �������
        }
    }
}
