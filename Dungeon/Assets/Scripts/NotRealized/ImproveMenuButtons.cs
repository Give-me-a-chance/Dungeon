using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImproveMenuButtons : MonoBehaviour
{
    public List<Image> DamageLvl = new List<Image>();
    public List<Image> FRLvl = new List<Image>();

    public TextMeshProUGUI damageprice;
    public Button ImproveDamage;
    public TextMeshProUGUI FrPrice;
    public Button improveFR;
   

    public TextMeshProUGUI DamageCount;
    public TextMeshProUGUI FRCount;

    public TextMeshProUGUI GoldCount;
    public int lvlDamageNow = 1;
    public int lvlFireRateNow = 1;
    public int damagechange;
    public float frchange;
    Connection con = new Connection();

    public GameObject ultPanel;
    public GameObject ultBlockPanel;



    private void Start()
    {

        lvlDamageNow = int.Parse(Stats.LvlsP.Split(' ')[0]);
        lvlFireRateNow = int.Parse(Stats.LvlsP.Split(' ')[1]);
        if (lvlDamageNow == 5 && lvlFireRateNow == 5)
        {
            ultPanel.SetActive(true);
            ultBlockPanel.SetActive(false);
        }
        GoldCount.text = Stats.GoldCount.ToString();

       //Damage 
        DamageLvl[0].color = Color.green;
        if (lvlDamageNow > 1)
            DamageCount.text = (10 + lvlDamageNow * damagechange).ToString();
        else
            DamageCount.text = "10";
        if (lvlDamageNow < 5)
        {
            DamageLvl[lvlDamageNow].color = Color.white;
            damageprice.text = (20 * (lvlDamageNow + 1)).ToString();
            if (Stats.GoldCount < int.Parse(damageprice.text))
                ImproveDamage.interactable = false;
        }
        if (lvlDamageNow == 5)
        {
            ImproveDamage.interactable = false;
            damageprice.text = "max";
        }
        for (int i = 1; i < lvlDamageNow; i++)
        {
            DamageLvl[i].color = Color.green;
        }


        //FireRate

        FRLvl[0].color = Color.green;
        if (lvlFireRateNow > 1)
            FRCount.text = $"{decimal.Round((decimal)(2 + lvlFireRateNow * frchange), 2).ToString()} /сек";
        else
            FRCount.text = "2 / сек";
        if (lvlFireRateNow < 5)
        {
            FRLvl[lvlFireRateNow].color = Color.white;
            FrPrice.text = (10 * (lvlFireRateNow + 1)).ToString();
            if (Stats.GoldCount < int.Parse(FrPrice.text))
                improveFR.interactable = false;

        }
        if (lvlFireRateNow == 5)
        {
            improveFR.interactable = false;
            FrPrice.text = "max";
        }
       
        for (int i = 1; i < lvlFireRateNow; i++)
        {
            FRLvl[i].color = Color.green;
        }

    }
    public void ImproveDamage_Click()
    {
        if (Stats.GoldCount >= int.Parse(damageprice.text))
        {
            Stats.GoldCount -= int.Parse(damageprice.text);
            Stats.LvlsP = $"{(int.Parse(Stats.LvlsP.Split(' ')[0]) + 1).ToString()} {lvlFireRateNow}";
            
            con.UpPistol();
        }
        Start();
    }

    public void ImproveFR_Click()
    {
        if (Stats.GoldCount >= int.Parse(FrPrice.text))
        {
            Stats.GoldCount -= int.Parse(FrPrice.text);
            Stats.LvlsP = $"{lvlDamageNow} {(int.Parse(Stats.LvlsP.Split(' ')[1]) + 1).ToString()}";
            con.UpPistol();
        }
        Start();
    }

   

    

}
