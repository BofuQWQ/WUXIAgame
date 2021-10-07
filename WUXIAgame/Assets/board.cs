using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    

    [SerializeField] int[] theboard;
   
    //  [SerializeField] List<int> theboard = new List<int>();
    void Start()
    {
        dicevalues = new int[1];
        theboard = new int[]{ 1, 1, 1, 2, 3 , 1, 1};
       /* 
        theboard.Add(1);
        theboard.Add(2);
        theboard.Add(3);
        */
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rolldice();
            
        }
        findlocation();
    }

    public int[] dicevalues;
    public int dicetotal;

    public void rolldice()
    {
        for (int i = 0; i < dicevalues.Length; i++)
        {
            dicevalues[i] = Random.Range(1, 7);
            dicetotal += dicevalues[i];
        }

    }


    public void findlocation()
    {
        
        if (theboard[dicetotal] == 1)
         {
             Debug.Log("1");
         }
         if (theboard[dicetotal] == 2)
         {
             Debug.Log("2");
         }
         if (theboard[dicetotal] ==  3)
         {
             Debug.Log("3");
         }
    }

   
}
