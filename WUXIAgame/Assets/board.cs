using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    {

    // [SerializeField] int[] board = new int[5];
    [SerializeField] List<int> theboard = new List<int>(1, 2, 3);
    void Start()
    {
        dicevalues = new int[1];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rolldice();
            findlocation();
        }
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
        /* if (board[dicetotal] == 1)
         {
             Debug.Log("1");
         }
         if (board[dicetotal] == 2)
         {
             Debug.Log("2");
         }
         if (board[dicetotal] == 3)
         {
             Debug.Log("3");
         }*/
    }


}
