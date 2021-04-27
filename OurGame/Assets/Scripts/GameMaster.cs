using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    private int SkillID = 0;
    public List<Skills> Skills;
    int[] possibleSkillID;
    private bool turn = true;
    private bool CastAttack = false;
    private bool CastSupport = false;
    int k = 0, v1 = 0, v2 = 0;
    public GameObject[] EnemyParty, TeamParty;
    public GameObject Target;
    public GameObject[] TeamTarget = new GameObject [2];
    private GameObject tmpTarget, tmpTeamTarget;
    public Spawn spawnObject;
    int EnemyesCount;
    bool End = true;
    void Start() {
        EnemyesCount = spawnObject.EnemyesOnSide;
    }
    void Update() {
        if (PlayerPrefs.GetInt("enemiesAlive")==0 && End) {
            Debug.Log("Выиграли");
            End = false;
        }

        if (PlayerPrefs.GetInt("teamAlive") == 0 && End) {
            Debug.Log("Проиграли");
            End = false;
        }

        if (Input.GetMouseButtonDown(0)) {
            Target = GetComponent<MouseTrack>().chelic;
            if (Target.tag == "Vrag" && TeamTarget[0] == null) {
                Target = null;
                return;
            }
        }
        if (Target != null && k == 0 && Target.tag == "Player" && Input.GetMouseButtonDown(0) && !Target.GetComponent<Vrag>().died) {
            k++;
            tmpTarget = Target.transform.Find("Skills").gameObject;
            if (Target != TeamTarget[0]) {
                tmpTarget.SetActive(!tmpTarget.activeSelf);
            }
            if (tmpTeamTarget!= null && TeamTarget[0] != null && TeamTarget[0].gameObject != Target.gameObject) {
                tmpTeamTarget.SetActive(!tmpTeamTarget.activeSelf);
            }
            TeamTarget[0] = Target;
            tmpTeamTarget = TeamTarget[0].transform.Find("Skills").gameObject;
        } else if (Target != null && k == 1 && Target.tag == "Player" && Input.GetMouseButtonDown(0)) {
            TeamTarget[1] = Target;
            k--;
        } else if (Target != null && k == 1 && Input.GetMouseButtonDown(0)) {
            k--;
        }       
        if (Target != null && turn && PlayerPrefs.GetInt("teamAlive") > 0) {
            if (Input.GetKeyDown(KeyCode.H)) {
                SkillID = 0;
                CastAttack = true;
            }
            if (Input.GetKeyDown(KeyCode.J)) {
                if (TeamTarget[0].GetComponent<Vrag>().ID == 1) {
                    SkillID = 2;
                    CastSupport = true;
                } else
                if (TeamTarget[0].GetComponent<Vrag>().ID == 2) {
                    SkillID = 1;
                    CastAttack = true;
                } else
                if (TeamTarget[0].GetComponent<Vrag>().ID == 3) {
                    SkillID = 7;
                    CastAttack = true;
                }
            }
        }

        if (CastAttack) {
            if (Target != null && Target.tag == "Vrag" && TeamTarget[0].tag == "Player") {
                possibleSkillID = TeamTarget[0].GetComponent<PossibleSkillsID>().possibleSkills;
                for (int i = 0; i < possibleSkillID.Length; i++) {
                    if (SkillID == possibleSkillID[i]) {
                        Skills[SkillID].Activate();                      
                        CastAttack = false;
                        turn = false;
                        if(Random.Range(0,101)>95) {
                            Debug.Log("У деда инсульт");
                            spawnObject.Team[3].GetComponent<Vrag>().TakeDamage(999);
                        }
                        return;
                    }
                }
                CastAttack = false;             
            } else CastAttack = false;
        }
        if (CastSupport) {
            if (Target != null && Target.tag == "Player") {
                possibleSkillID = TeamTarget[0].GetComponent<PossibleSkillsID>().possibleSkills;
                for (int i = 0; i < possibleSkillID.Length; i++) {
                    if (SkillID == possibleSkillID[i]) {
                        if (TeamTarget[1] == null) TeamTarget[1] = TeamTarget[0];
                        Skills[SkillID].Activate();
                        CastSupport = false;
                        turn = false;
                        if (tmpTeamTarget != null && TeamTarget[0] != null && TeamTarget[0].gameObject == TeamTarget[1].gameObject) {
                            tmpTeamTarget.SetActive(!tmpTeamTarget.activeSelf);
                        }
                        if (Random.Range(0, 101) > 95) {
                            Debug.Log("У деда инсульт");
                            spawnObject.Team[3].GetComponent<Vrag>().TakeDamage(999);
                        }
                        return;
                    }
                }
                CastSupport = false;
            } else { 
                CastSupport = false; 
            }
        }

       if (!turn) {
            if(TeamTarget[0] != null) tmpTeamTarget = TeamTarget[0].transform.Find("Skills").gameObject;
            if(TeamTarget[0].gameObject != Target.gameObject) tmpTeamTarget.SetActive(!tmpTeamTarget.activeSelf);
            tmpTeamTarget = null;
            Target = null;
            TeamTarget[0] = null;
            TeamTarget[1] = null;
            EnemyParty = spawnObject.Enemy;
            TeamParty = spawnObject.Team;
            if (PlayerPrefs.GetInt("enemiesAlive") > 0) {
                StartCoroutine(EnemyTurn(findEnemyToMove()));
            }
            Target = null;
            TeamTarget[0] = null;
            turn = true;
        }
    }

    int findEnemyToMove() {
        int T = v1 % EnemyesCount;
        if (EnemyParty[T].GetComponent<Vrag>().died) {
            v1++;
            return findEnemyToMove();
        }
        return T;
    }
    int findTeamToAttack() {
        int T = v2 % EnemyesCount;
        if (TeamParty[T].GetComponent<Vrag>().died) {
            v2++;
            return findTeamToAttack();
        }
        v2++;
        return T;
    }


    IEnumerator EnemyTurn(int T) {
        yield return new WaitForSeconds(1f);
        TeamTarget[0] = EnemyParty[T];
        possibleSkillID = TeamTarget[0].GetComponent<PossibleSkillsID>().possibleSkills;
        Target = TeamParty[findTeamToAttack()];
        SkillID = possibleSkillID[Random.Range(0, possibleSkillID.Length)];
        Skills[SkillID].Activate();
    }
}

