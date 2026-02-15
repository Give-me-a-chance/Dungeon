using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGun : MonoBehaviour
{
    public Button Gun1;
    public TextMeshProUGUI gun1text;
    public Button Gun2;
    public TextMeshProUGUI gun2text;
    public Button Gun3;
    public TextMeshProUGUI gun3text;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SelectedGun"))
        {
            if (PlayerPrefs.GetInt("SelectedGun") == 1)
            {
                gun1text.text = "Выбрано";
                Gun1.interactable = false;
                gun2text.text = "Выбрать";
                Gun2.interactable = true;
                gun3text.text = "Выбрать";
                Gun3.interactable = true;
            }
            if (PlayerPrefs.GetInt("SelectedGun") == 2)
            {
                gun2text.text = "Выбрано";
                Gun2.interactable = false;
                gun1text.text = "Выбрать";
                Gun1.interactable = true;
                gun3text.text = "Выбрать";
                Gun3.interactable = true;
                
            }
            if (PlayerPrefs.GetInt("SelectedGun") == 3)
            {
                gun3text.text = "Выбрано";
                Gun3.interactable = false;
                gun2text.text = "Выбрать";
                Gun2.interactable = true;
                gun1text.text = "Выбрать";
                Gun1.interactable = true;
            }
        }
    }
    public void Gun1_Click()
    {
        gun1text.text = "Выбрано";
        Gun1.interactable = false;
        gun2text.text = "Выбрать";
        Gun2.interactable = true;
        gun3text.text = "Выбрать";
        Gun3.interactable = true;
        PlayerPrefs.SetInt("SelectedGun", 1);
        PlayerPrefs.Save();
    }
    public void Gun2_Click()
    {
        gun2text.text = "Выбрано";
        Gun2.interactable = false;
        gun1text.text = "Выбрать";
        Gun1.interactable = true;
        gun3text.text = "Выбрать";
        Gun3.interactable = true;
        PlayerPrefs.SetInt("SelectedGun", 2);
        PlayerPrefs.Save();
    }

    public void Gun3_Click()
    {
        gun3text.text = "Выбрано";
        Gun3.interactable = false;
        gun2text.text = "Выбрать";
        Gun2.interactable = true;
        gun1text.text = "Выбрать";
        Gun1.interactable = true;
        PlayerPrefs.SetInt("SelectedGun", 3);
        PlayerPrefs.Save();
    }


}
