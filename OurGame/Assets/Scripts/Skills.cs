using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skills : MonoBehaviour
{
    public virtual SkillStats Stats { get; set; }
    public virtual void Activate() {
        Debug.Log("Activate");
    }
}
