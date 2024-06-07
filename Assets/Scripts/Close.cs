using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    private DataService _dataService;
    void Start() 
    {
        _dataService = new DataService();
    }
   public void QuitApplication()
    {
        // Сохраняем все необходимые данные перед выходом
        SaveGameData();

        // Закрываем приложение
        #if UNITY_EDITOR
            // Если мы находимся в редакторе Unity, останавливаем игру
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Если приложение запущено на устройстве, закрываем его
            Application.Quit();
        #endif
    }

    private void SaveGameData()
    {
        _dataService.OnDestroy();
    }
}
