using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public int SkillID = 0;
    public List<Skills> Skills;
    int[] possibleSkillID;
    private bool CastAttack = false;
    private bool CastSupport = false;

    public GameObject Target, TeamTarget;
    private GameObject tmpTarget, tmpTeamTarget;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Target = GetComponent<MouseTrack>().chelic;
        }
        if (Target != null && Target.tag == "Player" && Input.GetMouseButtonDown(0)) {
            tmpTarget = Target.transform.Find("Skills").gameObject;
            if (Target != TeamTarget) {
                tmpTarget.SetActive(!tmpTarget.activeSelf);
            }
            if (TeamTarget != null && TeamTarget.gameObject != Target.gameObject) {
                tmpTeamTarget.SetActive(!tmpTeamTarget.activeSelf);
            }
            TeamTarget = Target;
            tmpTeamTarget = TeamTarget.transform.Find("Skills").gameObject;
        }

        if (Input.GetKeyDown(KeyCode.H)) {
            SkillID = 0;
            CastAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            SkillID = 1;
            CastAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            SkillID = 2;
            CastSupport = true;
        }
        if (CastAttack) {
            possibleSkillID = TeamTarget.GetComponent<PossibleSkillsID>().possibleSkills;
            if (Target != null && Target.tag == "Vrag") {
                for (int i = 0; i < possibleSkillID.Length; i++) {
                    if (SkillID == possibleSkillID[i]) {
                        Skills[SkillID].Activate();
                        CastAttack = false;
                        break;
                    }
                }
                CastAttack = false;
            }
        } else {
            CastAttack = false;
        }

        if (CastSupport) {
            possibleSkillID = TeamTarget.GetComponent<PossibleSkillsID>().possibleSkills;
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
    }
}

