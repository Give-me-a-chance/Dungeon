using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject Main;
    public GameObject Reg;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void OnplayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Inventory()
    {
        SceneManager.LoadScene(2);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void TestScene()
    {
        SceneManager.LoadScene(4);
    }    

    public void Clear()
    {
        PlayerPrefs.DeleteAll();
        Main.SetActive(false);
        Reg.SetActive(true);
    }
}
