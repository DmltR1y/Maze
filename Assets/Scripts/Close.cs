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
        // ��������� ��� ����������� ������ ����� �������
        SaveGameData();

        // ��������� ����������
        #if UNITY_EDITOR
            // ���� �� ��������� � ��������� Unity, ������������� ����
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // ���� ���������� �������� �� ����������, ��������� ���
            Application.Quit();
        #endif
    }

    private void SaveGameData()
    {
        _dataService.OnDestroy();
    }
}
