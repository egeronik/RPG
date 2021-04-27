using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Skills
{
    public bool Status = false;

    public int Damage;

    private GameObject TeamT, T;

    [SerializeField]
    private SkillStats _stats;
    public override SkillStats Stats { get { return _stats; } set { _stats = value; } }

    public override void Activate()
    {
        Status = true;
    }

    void Update()
    {
        if (Status)
        {
            T = GetComponent<GameMaster>().TeamTarget[1];
            TeamT = GetComponent<GameMaster>().TeamTarget[0];

            TeamT.GetComponent<Animator>().SetTrigger("Heal");
            T.GetComponent<Vrag>().TakeDamage(Damage);
            if (T.GetComponent<Vrag>().currentHealth > 100) T.GetComponent<Vrag>().currentHealth = 100;
            Status = false;
        }
    }
}