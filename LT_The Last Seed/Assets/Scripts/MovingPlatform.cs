using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    [Tooltip("Destination to travel to")]
    public Vector3 pointB;

    [Tooltip("How long (seconds) to complete one cycle")]
    public float Duration;

    [Tooltip("Object tag to parent on collision. (Check with programmer before use)")]
    public string ObjectTag;

    IEnumerator Start()
    {
        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, Duration));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, Duration));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(ObjectTag))
            col.gameObject.GetComponent<Transform>().SetParent(this.gameObject.transform);
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag(ObjectTag))
            col.gameObject.GetComponent<Transform>().SetParent(null);
    }
}