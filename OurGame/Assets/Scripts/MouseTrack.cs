using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseTrack : MonoBehaviour
{
    public GameObject chelic;
    void Update()
    {
            CastRay();
    }
    void CastRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit) {
            chelic = hit.collider.gameObject;
        }
    }

}
