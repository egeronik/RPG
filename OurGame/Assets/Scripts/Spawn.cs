using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public int EnemyesOnSide = 4;
    public GameObject[] Team;
    public GameObject[] Enemy;
    public GameObject[] EnemyForest;
    public GameObject[] EnemyDesert;
    public GameObject[] SpawnTeam;
    public GameObject[] SpawnEnemy;
    bool[] EnemiesUsed = new bool[4];
    bool[] AlliesUsed = new bool [4];
    string Biome;
    void Start() {
        Biome = StateDataController.Biome;
        PlayerPrefs.SetInt("enemiesAlive", 0);
        PlayerPrefs.SetInt("teamAlive", 0);
        int value;

        for (int i = 0; i < Team.Length; i++) {
            value = Random.Range(0, 4);
            while (AlliesUsed[value]) {
                value = Random.Range(0, 4);
            }
            Vector3 vec = SpawnTeam[value].transform.position;
            vec.y += Team[i].GetComponent<BoxCollider2D>().size.y / 2;
            Team[i] = Instantiate(Team[i], vec, SpawnTeam[value].transform.rotation);
            
            PlayerPrefs.SetInt("teamAlive", PlayerPrefs.GetInt("teamAlive") + 1);
            AlliesUsed[value] = true;
        }

        for (int i = 0; i < 4; i++)
        {
            //Debug.Log(Team[i].GetComponent<Vrag>().currentHealth);
            if (!StateDataController.teamHealthIsFull)
            {
                Team[i].GetComponent<Vrag>().currentHealth = StateDataController.teamHp[i];
                Team[i].GetComponent<Vrag>().healthBar.SetHealt(StateDataController.teamHp[i]);
                StateDataController.teamMaxHp[i] = Team[i].GetComponent<Vrag>().maxHealth;
                //Debug.Log(Team[i].GetComponent<Vrag>().currentHealth);
            }
        }


        if (Biome == "Forest") {
            for (int i = 0; i < EnemyesOnSide; i++) {
                Enemy[i] = EnemyForest[Random.Range(0, 4)];
            }
        } else if (Biome == "Desert") {
            for (int i = 0; i < EnemyesOnSide; i++) {
                Enemy[i] = EnemyDesert[Random.Range(0, 4)];
            }
        }

        for (int i = 0; i < Enemy.Length; i++) {
            value = Random.Range(0, EnemyesOnSide);
            while (EnemiesUsed[value]) {
                value = Random.Range(0, EnemyesOnSide);
            }
            Vector3 vec = SpawnEnemy[value].transform.position;
            vec.y += Enemy[i].GetComponent<BoxCollider2D>().size.y / 2;
            Enemy[i] = Instantiate(Enemy[i], vec, SpawnEnemy[value].transform.rotation);
            PlayerPrefs.SetInt("enemiesAlive", PlayerPrefs.GetInt("enemiesAlive") + 1);
            EnemiesUsed[value] = true;
        }
        
    }

    private void Awake()
    {
        
    }

}
