﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public int SkillID = 0;
    public List<Skills> Skills;
    int[] possibleSkillID;
    private bool turn = true;
    private bool CastAttack = false;
    private bool CastSupport = false;
    int k = 0;
    public GameObject Target;
    public GameObject[] TeamTarget = new GameObject [2];
    private GameObject tmpTarget, tmpTeamTarget;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Target = GetComponent<MouseTrack>().chelic;
        }
        if (Target != null && k == 0 && Target.tag == "Player" && Input.GetMouseButtonDown(0)) {
            k++;
            tmpTarget = Target.transform.Find("Skills").gameObject;
            if (Target != TeamTarget[0]) {
                tmpTarget.SetActive(!tmpTarget.activeSelf);
            }
            if (TeamTarget[0] != null && TeamTarget[0].gameObject != Target.gameObject) {
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

        if (Input.GetKeyDown(KeyCode.H) && turn) {
            SkillID = 0;
            CastAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.J) && turn) {
            SkillID = 1;
            CastAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.K) && turn) {
            SkillID = 2;
            CastSupport = true;
        }

        if (CastAttack) {
            possibleSkillID = TeamTarget[0].GetComponent<PossibleSkillsID>().possibleSkills;
            if (Target != null && Target.tag == "Vrag") {
                for (int i = 0; i < possibleSkillID.Length; i++) {
                    if (SkillID == possibleSkillID[i]) {
                        Skills[SkillID].Activate();
                        CastAttack = false;
                        //turn = false;
                        break;
                    }
                }
                CastAttack = false;
            }
        } else {
            CastAttack = false;
        }

        if (CastSupport) {
            possibleSkillID = TeamTarget[0].GetComponent<PossibleSkillsID>().possibleSkills;
            if (Target != null && Target.tag == "Player") {
                for (int i = 0; i < possibleSkillID.Length; i++) {
                    if (SkillID == possibleSkillID[i]) {
                        Skills[SkillID].Activate();
                        CastSupport = false;
                        break;
                    }
                }
                CastSupport = false;
            }
        } else {
            CastSupport = false;
        }

       /* if (!turn) {
            possibleSkillID = Target.GetComponent<PossibleSkillsID>().possibleSkills;
            if (TeamTarget != null && TeamTarget[1].tag == "Player") {
                
                Skills[SkillID].Activate();
                CastSupport = false;
                turn = false;
                }           
            }*/
    }
}

