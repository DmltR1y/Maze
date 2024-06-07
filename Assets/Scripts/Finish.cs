using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private DataService _dataService;

    void Start() {
        _dataService = new DataService();
    }

// Вызывается, когда другой объект касается объекта финиша
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, касается ли объект финиша игрока
        if (collision.gameObject.tag == "Player")
        {

            _dataService.UpdateUserTime();
            SceneManager.LoadScene("Menu");

        }
    }
}
