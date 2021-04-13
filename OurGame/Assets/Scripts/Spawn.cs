using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public const int PersonsOnSide = 4;
    public GameObject[] Team = new GameObject[PersonsOnSide];
    public GameObject[] Enemy = new GameObject[PersonsOnSide];
    public GameObject[] SpawnTeam = new GameObject[PersonsOnSide];
    public GameObject[] SpawnEnemy = new GameObject[PersonsOnSide];
    bool[] EnemiesUsed = new bool[PersonsOnSide];
    bool[] AlliesUsed = new bool [PersonsOnSide];

    void Start() {
        int value;
        for (int i = 0; i < Team.Length; i++) {
            value = Random.Range(0, PersonsOnSide);
            while (AlliesUsed[value]) {
                value = Random.Range(0, PersonsOnSide);
            }
            Instantiate(Team[i], SpawnTeam[value].transform.position, SpawnTeam[value].transform.rotation);
            AlliesUsed[value] = true;
        }
        for (int i = 0; i < Enemy.Length; i++) {
            value = Random.Range(0, PersonsOnSide);
            while (EnemiesUsed[value]) {
                value = Random.Range(0, PersonsOnSide);
            }
            Instantiate(Enemy[i], SpawnEnemy[value].transform.position, SpawnEnemy[value].transform.rotation);
            EnemiesUsed[value] = true;
        }
    }
}
