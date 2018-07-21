using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [Tooltip("Tag of the object to damage")]
    public string ObjectTag;

    [Tooltip("Immediately kills the object?")]
    public bool KillObject;

    [Tooltip("Damages Object?")]
    public bool DamageObject;

    [Tooltip("How much to damage by if damaging")]
    public float DamageRate = 10f;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(ObjectTag) == true)
        {
            if (KillObject)
            {
                Health H = col.gameObject.GetComponent<Health>();

                if (H == null) return;

                H.HealthPoints = 0;
            }
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (DamageObject)
        {
            Health H = col.gameObject.GetComponent<Health>();

            if (H == null) return;

            H.HealthPoints -= DamageRate;
        }
    }
}
