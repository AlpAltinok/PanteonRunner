using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private inGameRanking ig;
    private GameObject[] runner;
    List<RankingSistem> sortArray = new List<RankingSistem>();
    private void Awake()
    {
        instance = this;
        runner = GameObject.FindGameObjectsWithTag("Runner");
        ig = FindObjectOfType<inGameRanking>();
    }
    void Start()
    {
        for(int i = 0; i < runner.Length; i++)
        {
            sortArray.Add(runner[i].GetComponent<RankingSistem>());
        }
        
    }
    void CalculateRanking()
    {
        sortArray=sortArray.OrderBy(x => x.distance).ToList();

        sortArray[0].rank = 1;
        sortArray[1].rank = 2;
        sortArray[2].rank = 3;
        sortArray[3].rank = 4;
        sortArray[4].rank = 5;

        ig.a = sortArray[4].name;
        ig.b = sortArray[3].name;
        ig.c= sortArray[2].name;
        ig.d= sortArray[1].name;
        ig.e = sortArray[0].name;

    }

    
    void Update()
    {
        CalculateRanking();
    }
}
