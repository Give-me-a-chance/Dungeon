using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine;

public class Connection : MonoBehaviour
{
    SqliteCommand cmd;
    public SqliteConnection PlayersDb;
    private string _path;

    // RegAuto regut = new();
    
    public void Start()
    {
        _path = Path.Combine(Application.streamingAssetsPath, "GunPlayers.db");
        Debug.Log(_path);  
    }
    public void OpenConnection()
    {
        //  _path = Application.persistentDataPath + "/StreamingAssets/GunPlayers.db";
        _path = Path.Combine(Application.streamingAssetsPath, "GunPlayers.db");
        PlayersDb = new SqliteConnection("URI=file:" + _path);
        
        cmd = new SqliteCommand();
       
        PlayersDb.Open();
        


        if (PlayersDb.State == ConnectionState.Open)
        {
            Debug.Log("¡‡Á‡");
            cmd.Connection = PlayersDb;
        }
        else
            Debug.Log("Eror");

        

    }

    public void Reg(string a)
    {
        // ExecuteQueryWithoutAnsw("INSERT INTO Users (Login, Password) VALUES ('" + _loginField.text + "','" + _paswwordField.text + "');");


        OpenConnection();
        cmd.Connection = PlayersDb;             /// –¿¡Œ“¿≈““““““!!!!!!
        cmd.CommandText = "Select* from players where Name = '" + a + "'";


    }

    public void AddUser(TMP_InputField log, TMP_InputField pass)
    {
        OpenConnection();
        cmd.Connection = PlayersDb;             /// –¿¡Œ“¿≈““““““!!!!!!
        cmd.CommandText = "INSERT INTO players (Name, Password, GoldCount, PLvls, SGLvls, ARLvls) VALUES ('" + log.text + "','" + pass.text + "','" + '0' + "','" + "1 1" + "','" + '0' + "','" + '0' + "'); ";
        Debug.Log(cmd.ExecuteNonQuery());

    }

    public bool GetLogs(List<string> a, string login)
    {
        List<string> logs = new List<string>();
        OpenConnection();
        cmd.CommandText = "Select Name from players";
        SqliteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
            logs.Add(reader[0].ToString());
        reader.Close();
        if (logs.Contains(login))
        { Debug.Log("≈ÒÚ¸"); return true; }
        else
        { Debug.Log("ÕÂÚÛ"); return false; }
    }

    public bool CheckPass(TMP_InputField log, TMP_InputField pass)
    {
        bool b = false;
        OpenConnection();
        cmd.CommandText = "Select Name, Password from players where Name = '" + log.text + "'";
        SqliteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (pass.text == reader[1].ToString())
            { b = true; break; }
        }
        reader.Close();
        return b;
    }

    public void CloseConnection()
    {
        
        PlayersDb.Close();
        cmd.Dispose();
    }

    public void GetLvls(string name)
    {
        OpenConnection();
        cmd.Connection = PlayersDb;
        cmd.CommandText = "select PLvls, SGLvls, ARLvls, GoldCount from players where Name = '" + name + "'";
        SqliteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Stats.LvlsP = reader[0].ToString();
            Stats.LvlsSG = reader[1].ToString();
            Stats.LvlsAR = reader[2].ToString();
            Stats.GoldCount = int.Parse(reader[3].ToString());
        }

        reader.Close();
    }

    public void UpPistol()
    {
        OpenConnection();
        string name = RegAuto.Name;
        string lvls = Stats.LvlsP.ToString();
        int gold = Stats.GoldCount;
        cmd.Connection = PlayersDb;
        cmd.CommandText = "Update Players set GoldCount = '" + gold + "' where name = '" + name + "'";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "Update Players set Plvls = '"+ lvls +"' where name = '"+ name +"'";
        cmd.ExecuteNonQuery();
        Debug.Log("”ÎÛ˜¯ÂÌËÂ!");
    }

    public void UpSG()
    {
        OpenConnection();
        string name = RegAuto.Name;
        string lvls = Stats.LvlsSG.ToString();
        int gold = Stats.GoldCount;
        cmd.Connection = PlayersDb;
        cmd.CommandText = "Update Players set GoldCount = '" + gold + "' where name = '" + name + "'";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "Update Players set SGLvls = '" + lvls + "' where name = '" + name + "'";
        cmd.ExecuteNonQuery();
        Debug.Log("”ÎÛ˜¯ÂÌËÂ!");
    }

    public void UpAR()
    {
        OpenConnection();
        string name = RegAuto.Name;
        string lvls = Stats.LvlsAR.ToString();
        int gold = Stats.GoldCount;
        cmd.Connection = PlayersDb;
        cmd.CommandText = "Update Players set GoldCount = '" + gold + "' where name = '" + name + "'";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "Update Players set ARLvls = '" + lvls + "' where name = '" + name + "'";
        cmd.ExecuteNonQuery();
        Debug.Log("”ÎÛ˜¯ÂÌËÂ!");
    }

    public void Unlock()
    {
        OpenConnection();
        string name = RegAuto.Name;
        string lvlsSG = Stats.LvlsSG.ToString();
        string lvlsAR = Stats.LvlsAR.ToString();
        int gold = Stats.GoldCount;
        cmd.Connection = PlayersDb;
        cmd.CommandText = "Update Players set GoldCount = '" + gold + "' where name = '" + name + "'";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "Update Players set SGLvls = '" + lvlsSG + "' where name = '" + name + "'";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "Update Players set ARLvls = '" + lvlsAR + "' where name = '" + name + "'";
        cmd.ExecuteNonQuery();
        Debug.Log("–‡Á·ÎÓÍËÓ‚Í‡");
    }

    public void GetGold()
    {
        OpenConnection();
        string name = RegAuto.Name;
        int gold = Stats.GoldCount;
        cmd.Connection = PlayersDb;
        cmd.CommandText = "Update Players set GoldCount = '" + gold + "' where name = '" + name + "'";
        cmd.ExecuteNonQuery();


    }
}
