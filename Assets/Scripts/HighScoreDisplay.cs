using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using SQLite4Unity3d;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public GameObject userRecordPrefab; // ������ ��� ����������� ������ ������������
    public Transform contentPanel; // ������ ��� ���������� �������

    private DataService _dataService; // ������ 

    private void Start()
    {
        _dataService = DataService.Instance; // ������� � �����
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        List<User> highScores = _dataService.GetHighScores(); // �������� ������ ��������
        foreach (User user in highScores)
        {
            GameObject newRecord = Instantiate(userRecordPrefab, contentPanel); // ������� ����� ������� ���������� ��� ������ ������
            TextMeshProUGUI usernameText = newRecord.transform.Find("UsernameText").GetComponent<TextMeshProUGUI>(); // ������� ������� Text ��� ����� ������������
            TextMeshProUGUI timeText = newRecord.transform.Find("TimeText").GetComponent<TextMeshProUGUI>(); // ������� ������� Text ��� �������

            usernameText.text = user.Username; // ������������� ��� ������������
            timeText.text = user.Time.ToString(); // ������������� �����
        }
    }
}
