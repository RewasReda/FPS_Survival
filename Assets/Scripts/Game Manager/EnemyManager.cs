using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager instance;

    [SerializeField]
    private GameObject boar_Prefab;

    [SerializeField]
    private GameObject cannibal_Prefab;


    public Transform[] boar_SpawnPoints;
    public Transform[] cannibal_SpawnPoints;


    [SerializeField]
    private int cannibal_Enemy_Count;

    [SerializeField]
    private int boar_Enemy_Count;

    private int initial_Boar_Count;
    private int initial_Cannibal_Count;

    public float wait_Before_Spawn_Enemies_Time = 10f;


    private void Awake()
    {
        MakeInstance();

    }

    // Start is called before the first frame update


    void Start()
    {

        initial_Cannibal_Count = cannibal_Enemy_Count;
        initial_Boar_Count = boar_Enemy_Count;

        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");
    }

    // Update is called once per frame
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void SpawnEnemies()
    {
        SpawnBoars();

        SpawnCannibals();

    }
    void SpawnBoars()
    {
        int index = 0;

        for (int i = 0; i < boar_Enemy_Count; i++)
        {

            if (index >= boar_SpawnPoints.Length)
            {
                index = 0;
            }

            Instantiate(boar_Prefab, boar_SpawnPoints[index].position, Quaternion.identity);

            index++;

        }

        boar_Enemy_Count = 0;

    }
    void SpawnCannibals()
    {
        int index = 0;

        for (int i = 0; i < cannibal_Enemy_Count; i++)
        {

            if (index >= cannibal_SpawnPoints.Length)
            {
                index = 0;
            }

            Instantiate(cannibal_Prefab, cannibal_SpawnPoints[index].position, Quaternion.identity);

            index++;

        }

        cannibal_Enemy_Count = 0;

    }


    public void EnemyDied(bool cannibal)
    {
        if (cannibal)
        {

            cannibal_Enemy_Count++;

            if (cannibal_Enemy_Count > initial_Cannibal_Count)
            {
                cannibal_Enemy_Count = initial_Cannibal_Count;
            }
        }

        else
        {

            boar_Enemy_Count++;

            if (boar_Enemy_Count > initial_Boar_Count)
            {
                boar_Enemy_Count = initial_Boar_Count;
            }
        }
    }

    IEnumerator CheckToSpawnEnemies()
    {
        yield return new WaitForSeconds(wait_Before_Spawn_Enemies_Time);
        SpawnBoars();
        SpawnCannibals();
        StartCoroutine("CheckToSpawnEnemies");
    }

    public void StopSpawning()
    {
        StopCoroutine("CheckToSpawnEnemies");
    }
}
