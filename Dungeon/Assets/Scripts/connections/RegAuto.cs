using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;

public class RegAuto : MonoBehaviour
{
    [SerializeField] TMP_InputField _loginField;
    [SerializeField] TMP_InputField _paswwordField;
    [SerializeField] TMP_InputField _paswwordreqField;
    [SerializeField] TextMeshProUGUI _Error;
    [SerializeField] GameObject _Regcanvas;
    [SerializeField] GameObject MainMenu;


    Connection connection = new();
  //  Stats stats = new Stats();
    public static string Name { get; set; }


    private void Start()
    {
        if (PlayerPrefs.HasKey("NameUser"))
        {
            Name = PlayerPrefs.GetString("NameUser");
            connection.GetLvls(PlayerPrefs.GetString("NameUser"));
            _Regcanvas.SetActive(false);
            MainMenu.SetActive(true);
        }
    }

    public void Check()
    {
        if (_loginField.text == "" || _paswwordField.text == "" || _paswwordreqField.text == "")
        {
            _Error.text = "Не все поля заполнены";

        }
        else
        {
            List<string> Logins = new List<string>();
            string trylogin = _loginField.text;
            connection.OpenConnection();
            if (connection.GetLogs(Logins, trylogin) == false)
            { Name = _loginField.text; Registration(); connection.Reg(_loginField.text); }
            else
            { _Error.text = "Логин уже существует"; }
        }
    }
    public void Auto()
    {
        if (_loginField.text == "" || _paswwordField.text == "")
        {
            _Error.text = "Не все поля заполнены";

        }
        else
        {
            connection.OpenConnection();
            List<string> Logins = new List<string>();
            string trylogin = _loginField.text;
            if (connection.GetLogs(Logins, trylogin) == true)
            {
                Name = _loginField.text;
                PlayerPrefs.SetString("NameUser", Name);
                PlayerPrefs.Save();
                connection.GetLvls(Name);
                if (connection.CheckPass(_loginField, _paswwordField) == true)
                {
                    _Regcanvas.SetActive(false);
                    MainMenu.SetActive(true);
                }
                else
                { _Error.text = "Неверный пароль"; }
            }
            else
            { _Error.text = "Логина не существует"; }
        }

    }



    public void Registration()
    {
        connection.AddUser(_loginField, _paswwordField);
        Name = _loginField.text;
        PlayerPrefs.SetString("NameUser", Name);
        PlayerPrefs.Save();
        connection.GetLvls(Name);
        Debug.Log(string.Format("Ok"));

        _Regcanvas.SetActive(false);
        MainMenu.SetActive(true);
    }


}
