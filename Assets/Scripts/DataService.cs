using UnityEngine;
using System.Collections;
using SQLite4Unity3d;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class DataService {

    private SQLiteConnection _connection;
    private static DataService _instance;
    private const int MaxUsers = 15; // Максимальное количество пользователей
    private const int MaxLength = 15; // Максимальная длина логина и пароля

    public static DataService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataService();
            }
            return _instance;
        }
    }

    public DataService(){
        // Путь к папке с базами данных на Android
        string folder = Application.persistentDataPath;
        string databaseName = "MyDatabase.db";
        string dbPath = Path.Combine(folder, databaseName);

        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     
    }

    public void OnDestroy(){
        _connection.Close();
    }

    public void CreateDB(){
        _connection.CreateTable<User>();
    }

     public bool CreateUser(string username, string password) {
        // Проверяем длину логина и пароля
        if (username.Length > MaxLength) {
            Debug.Log("Логин и пароль должны быть не длиннее 15 символов.");
            return false;
        }

        // Проверяем количество существующих пользователей
        int userCount = _connection.Table<User>().Count();
        if (userCount >= MaxUsers) {
            Debug.Log("Достигнуто максимальное количество пользователей.");
            return false;
        }

        var existingUser = _connection.Table<User>().Where(x => x.Username == username).FirstOrDefault();
        if (existingUser == null) {
            var user = new User {
                Username = username,
                Password = password
            };
            _connection.Insert(user);
            return true;
        } else {
            Debug.Log("Пользователь с таким логином уже существует.");
            return false;
        }
    }

    public bool CheckUser(string username, string password){
        var user = _connection.Table<User>().Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        return user != null;
    }

    public void UpdateUserTime()
    {
        string username = DataTransfer.Username;
        float newTime = DataTransfer.TimeLeft;
        var userTime = _connection.Table<User>().Where(x => x.Username == username).FirstOrDefault();
        if (userTime != null && newTime > userTime.Time)
        {
            userTime.Time = newTime;
            _connection.Update(userTime);
        }
        else if (userTime == null)
        {
            _connection.Insert(new User { Username = username, Time = newTime });
        }
    }

    public List<User> GetHighScores()
    {
        return _connection.Table<User>().OrderByDescending(u => u.Time).ToList();
    }

}

public class User {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [MaxLength(15)] // Устанавливаем максимальную длину для логина
    public string Username { get; set; }
    [MaxLength(15)] // Устанавливаем максимальную длину для пароля
    public string Password { get; set; }
    public float Time { get; set; }
}