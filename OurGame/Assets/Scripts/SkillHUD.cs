using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHUD : MonoBehaviour {

    public SkillStats Stats;

    public Image art;

    public Text description;
    public Text Name;

    void Start() {
        //Name.text = Stats.name;
        //description.text = Stats.description;
        art.sprite = Stats.artwork;
    }

}