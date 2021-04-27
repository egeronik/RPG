using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAttack : Skills
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
            T = GetComponent<GameMaster>().Target;
            TeamT = GetComponent<GameMaster>().TeamTarget[0];

            TeamT.GetComponent<Animator>().SetTrigger("Attack7");
            T.GetComponent<Vrag>().TakeDamage(Damage);
            StartCoroutine(DoubleAttackWait());
            Status = false;
        }
    }
    IEnumerator DoubleAttackWait() {
        yield return new WaitForSeconds(0.5f);
        TeamT.GetComponent<Animator>().SetTrigger("Attack7");
        T.GetComponent<Vrag>().TakeDamage(Damage);
    }
}