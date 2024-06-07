using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using SQLite4Unity3d;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public GameObject userRecordPrefab; // Префаб для отображения записи пользователя
    public Transform contentPanel; // Панель для добавления записей

    private DataService _dataService; // Ссылка 

    private void Start()
    {
        _dataService = DataService.Instance; // Находим в сцене
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        List<User> highScores = _dataService.GetHighScores(); // Получаем список рекордов
        foreach (User user in highScores)
        {
            GameObject newRecord = Instantiate(userRecordPrefab, contentPanel); // Создаем новый элемент интерфейса для каждой записи
            TextMeshProUGUI usernameText = newRecord.transform.Find("UsernameText").GetComponent<TextMeshProUGUI>(); // Находим элемент Text для имени пользователя
            TextMeshProUGUI timeText = newRecord.transform.Find("TimeText").GetComponent<TextMeshProUGUI>(); // Находим элемент Text для времени

            usernameText.text = user.Username; // Устанавливаем имя пользователя
            timeText.text = user.Time.ToString(); // Устанавливаем время
        }
    }
}
