using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class unlock : MonoBehaviour
{
    // Start is called before the first frame update
    public bool sglock = true;
    public bool arlock = true;

    public TextMeshProUGUI GoldCount;

    public TextMeshProUGUI sgprice;
    public GameObject sgPanel;
    public TextMeshProUGUI arprice;
    public GameObject arPanel;

    public Button sgunlock;
    public Button arunlock;

    public GameObject SgBlock;
    public GameObject ArBlock;

    Connection con = new Connection();
    private void Start()
    {
        if (Stats.LvlsSG != "0")
            sglock = false;
        if (Stats.LvlsAR != "0")
            arlock = false;


        if (sglock == false)
        { SgBlock.SetActive(false); sgPanel.SetActive(true); }
        if (arlock == false)
        { ArBlock.SetActive(false); arPanel.SetActive(true); }

        if (Stats.GoldCount < int.Parse(sgprice.text))
            sgunlock.interactable = false;

        if (Stats.GoldCount < int.Parse(arprice.text))
            arunlock.interactable = false;
    }


    public void SgUnlock_Click()
    {
        if (Stats.GoldCount >= int.Parse(sgprice.text))
        {
            SgBlock.SetActive(false);
            sgPanel.SetActive(true);
            Stats.GoldCount -= int.Parse((sgprice.text).ToString());
            Stats.LvlsSG = "1 1";
            GoldCount.text = Stats.GoldCount.ToString();
            con.Unlock();
        }
    }

    public void ARUnlock_Click()
    {
        if (Stats.GoldCount >= int.Parse(arprice.text))
        {
            ArBlock.SetActive(false);
            arPanel.SetActive(true);
            Stats.GoldCount -= int.Parse((arprice.text).ToString());
            Stats.LvlsAR = "1 1";
            GoldCount.text = Stats.GoldCount.ToString();
            con.Unlock();
        }
    }


}


