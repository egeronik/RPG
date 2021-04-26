using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public int EnemyesOnSide = 4;
    public GameObject[] Team;
    public GameObject[] Enemy;
    public GameObject[] SpawnTeam;
    public GameObject[] SpawnEnemy;
    bool[] EnemiesUsed = new bool[4];
    bool[] AlliesUsed = new bool [4];

    void Start() {
        PlayerPrefs.SetInt("enemiesAlive", 0);
        PlayerPrefs.SetInt("teamAlive", 0);
        int value;

        for (int i = 0; i < Team.Length; i++) {
            value = Random.Range(0, 4);
            while (AlliesUsed[value]) {
                value = Random.Range(0, 4);
            }
            Team[i] = Instantiate(Team[i], SpawnTeam[value].transform.position, SpawnTeam[value].transform.rotation);
            PlayerPrefs.SetInt("teamAlive", PlayerPrefs.GetInt("teamAlive") + 1);
            AlliesUsed[value] = true;
        }

        for (int i = 0; i < Enemy.Length; i++) {
            value = Random.Range(0, EnemyesOnSide);
            while (EnemiesUsed[value]) {
                value = Random.Range(0, EnemyesOnSide);
            }
            Enemy[i] = Instantiate(Enemy[i], SpawnEnemy[value].transform.position, SpawnEnemy[value].transform.rotation);
            PlayerPrefs.SetInt("enemiesAlive", PlayerPrefs.GetInt("enemiesAlive") + 1);
            EnemiesUsed[value] = true;
        }
    }
}
