using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public int SkillID = 0;
    public List<Skills> Skills;
    private bool Cast = false;

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
            Cast = true;
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            SkillID = 1;
            Cast = true;
        }

        if (Cast) {
            if (Target != null && Target.tag == "Vrag") {
                Skills[SkillID].Activate();
                Cast = false;
            }
        } else {
            Cast = false;
        }
    }
}

