using UnityEngine;
using System.Collections;
using SQLite4Unity3d;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO; 

public class AuthService : MonoBehaviour {

    private DataService _dataService;
    private SQLiteConnection _connection;

    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TextMeshProUGUI countdownText;


    void Start() {
            _dataService = new DataService();
            _dataService.CreateDB();
    }

    public void RegisterUser() {
        string username = usernameField.text;
        var md5 = MD5.Create();
		var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(passwordField.text));
        string password = Convert.ToBase64String(hash);
        bool userCreated = _dataService.CreateUser(username, password);
        if(userCreated) {
            DataTransfer.Username = username;
            Debug.Log("������������ ������� ���������������.");
            countdownText.text = "������������ ������� ���������������.";
        } else {
            Debug.Log("������������ � ����� ������� ��� ����������.");
            countdownText.text = "����� ������� ������� ��� ����� ������������ ��� ���������� ��� ��������� �������� �������������";
        }
    }

    public void LoginUser() {
        string username = usernameField.text;
        var md5 = MD5.Create();
		var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(passwordField.text));
        string password = Convert.ToBase64String(hash);
        bool validUser = _dataService.CheckUser(username, password);
        if(validUser) {
            DataTransfer.Username = username;
            SceneManager.LoadScene("Menu");
            Debug.Log("�������� ���� � �������.");
        } else {
            Debug.Log("�������� ����� ��� ������.");
            countdownText.text = "�������� ����� ��� ������.";
        };
    }

}




