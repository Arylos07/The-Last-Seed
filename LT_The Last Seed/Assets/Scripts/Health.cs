using UnityEngine;
using System.Collections;
//------------------------------
public class Health : MonoBehaviour
{
    public bool Suicide;
    //------------------------------
    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }

        set
        {
            _HealthPoints = value;

            if (_HealthPoints <= 0)
            {
                gameObject.SetActive(false);
                if(gameObject.CompareTag("Player"))
                    Debug.Log("Press R to restart");
            }
        }
    }
    //------------------------------
    [SerializeField]
    private float _HealthPoints = 100f;

    private void Update()
    {
        if (Suicide == true && Input.GetKeyDown(KeyCode.E))
            gameObject.GetComponent<Health>().HealthPoints = 0;
    }
}
//------------------------------