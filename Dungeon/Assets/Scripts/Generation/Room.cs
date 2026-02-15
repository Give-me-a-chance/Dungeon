using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject DoorD;
    public GameObject DoorU;
    public GameObject DoorL;
    public GameObject DoorR;
    public GameObject[] LightSources;
    public Simpleenemy[] Enemyes;
    public Transform FirstPoint;
    public Transform LastPoint;
    public bool IsStart;
    public AidHealing Aid;
    
    public void RotateRoom()
    {
        int count = Random.Range(0, 4);

        for (int i = 0; i < count; i++)
        {
            transform.Rotate(0, 90, 0);

            GameObject tmp = DoorL;
            DoorL = DoorD;
            DoorD = DoorR;
            DoorU = tmp;
        }
    }

    public void Start()
    {
        if (LightSources.Length > 0)
        {
            int destroyValue = Random.Range(0, LightSources.Length - 1);
            for (int i = 0; i < destroyValue; i++)
            {
                int index = Random.Range(0, LightSources.Length);
                Destroy(LightSources[index]);
            }
        }
        if (IsStart == false)
        {
            AIGenerate();
            AidGenerate();
        }

    }
    public void AIGenerate()
    {
        int count = Random.Range(2, 5);
        for (int i = 0; i < count; ++i)
        {
            int type = Random.Range(0, Enemyes.Length);
            Simpleenemy enemy = Instantiate(Enemyes[type]);
            enemy.transform.position = new Vector3(Random.Range(FirstPoint.position.x,LastPoint.position.x), 5.6f, Random.Range(FirstPoint.position.z,LastPoint.position.z));
            
        }
    }
    public void AidGenerate()
    {
        int count = Random.Range(0, 4);
        AidHealing aid = Instantiate(Aid);
        aid.transform.position = new Vector3(Random.Range(FirstPoint.position.x, LastPoint.position.x), 5.6f, Random.Range(FirstPoint.position.z, LastPoint.position.z));
    }

    
}
