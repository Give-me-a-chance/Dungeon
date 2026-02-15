using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ImproveSG : MonoBehaviour
{
    public List<Image> BSLvl = new List<Image>();
    public List<Image> ScatterLvl = new List<Image>();

    public TextMeshProUGUI BSprice;
    public Button ImproveBS;
    public TextMeshProUGUI ScatterPrice;
    public Button improveScatter;


    public TextMeshProUGUI BsCount;
    public TextMeshProUGUI ScatterCount;

    public TextMeshProUGUI GoldCount;
    public int lvlBSNow = 1;
    public int lvlScatterRateNow = 1;
    public int BSchange;
    public float Scatterchange;
    Connection con = new Connection();
    public GameObject ultPanel;
    public GameObject ultBlockPanel;

    private void Start()
    {

        lvlScatterRateNow = int.Parse(Stats.LvlsSG.Split(' ')[0]);
        lvlBSNow = int.Parse(Stats.LvlsSG.Split(' ')[1]);
        

        GoldCount.text = Stats.GoldCount.ToString();
        if (lvlScatterRateNow == 5 && lvlBSNow == 5)
        {
            ultPanel.SetActive(true);
            ultBlockPanel.SetActive(false);
        }

        //BS
        BSLvl[0].color = Color.green;
        if (lvlBSNow > 1)
            BsCount.text = (40 + lvlBSNow * BSchange).ToString();
        else
            BsCount.text = "40";
        if (lvlBSNow < 5)
        {
            BSLvl[lvlBSNow].color = Color.white;
            BSprice.text = (100 * (lvlBSNow + 1)).ToString();
            if (Stats.GoldCount < int.Parse(BSprice.text))
                ImproveBS.interactable = false;
           
        }
        if (lvlBSNow == 5)
        {
            ImproveBS.interactable = false;
            BSprice.text = "max";
        }
        for (int i = 0; i < lvlBSNow; i++)
        {
            BSLvl[i].color = Color.green;
        }


        //Scatter
        ScatterLvl[0].color = Color.green;
        if (lvlScatterRateNow > 1)
            ScatterCount.text = $"{(100 - lvlScatterRateNow * Scatterchange).ToString()}%";
        else
            ScatterCount.text = "100%";
        if (lvlScatterRateNow < 5)
        {
            ScatterLvl[lvlScatterRateNow].color = Color.white;
            ScatterPrice.text = (100 * (lvlScatterRateNow + 1)).ToString();
            if (Stats.GoldCount < int.Parse(ScatterPrice.text))
                improveScatter.interactable = false;
            

        }
        if (lvlScatterRateNow == 5)
        {
            improveScatter.interactable = false;
            ScatterPrice.text = "max";
        }
        for (int i = 1; i < lvlScatterRateNow; i++)
        {
            ScatterLvl[i].color = Color.green;
        }




    }
    public void ImproveScatter_Click()
    {
        if (Stats.GoldCount >= int.Parse(ScatterPrice.text))
        {
            Stats.GoldCount -= int.Parse(ScatterPrice.text);
            Stats.LvlsSG = $"{((int.Parse(Stats.LvlsSG.Split(' ')[0])) + 1).ToString()} {lvlBSNow}";
            Debug.Log(Stats.LvlsSG);
            con.UpSG();
        }
        Start();

    }
    public void ImproveBS_Click()
    {
        if (Stats.GoldCount >= int.Parse(BSprice.text))
        {
            Stats.GoldCount -= int.Parse(BSprice.text);
            Stats.LvlsSG = $"{lvlScatterRateNow} {((int.Parse(Stats.LvlsSG.Split(' ')[1])) + 1).ToString()}";
            Debug.Log(Stats.LvlsSG);
            con.UpSG();
        }
        Start();
    }

    
}
