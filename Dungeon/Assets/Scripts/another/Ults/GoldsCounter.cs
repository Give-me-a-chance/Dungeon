using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoldsCounter : MonoBehaviour
{
    public static int Kills { get; set; }
    public static float Time { get; set;}
    public TextMeshProUGUI killscount;
    public TextMeshProUGUI timecount;
    public TextMeshProUGUI goldForKills;
    public TextMeshProUGUI goldForTime;
    public TextMeshProUGUI Status;
    Connection con = new Connection();
    public Button btmenu;
    
    void Start()
    {
        Cursor.visible = Cursor.visible;
        
        if (Time > 1)
        {
            killscount.text = Kills.ToString();
            goldForKills.text = ((int)Kills * 5).ToString();
            timecount.text = Time.ToString();
            goldForTime.text = Mathf.Round(10000 / Time).ToString();
            Stats.GoldCount += (int)Kills * 5;
            Stats.GoldCount += (int)Mathf.Round(10000 / Time);
            Status.text = (Kills * 5 + (int)Mathf.Round(10000 / Time)).ToString();
        }
        else
        {
            killscount.text = Kills.ToString();
            Stats.GoldCount += (int)Kills * 5;
            goldForKills.text = ((int)Kills * 5).ToString();
            timecount.text = Time.ToString();
            goldForTime.text = "0";
            Stats.GoldCount += (int)Kills * 5;
            Status.text = ((int)Kills * 5).ToString();
        }    
        con.GetGold();
    }
    public void OnClick()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    
}
