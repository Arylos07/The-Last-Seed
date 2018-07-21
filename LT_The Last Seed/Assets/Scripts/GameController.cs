using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Tooltip("If true, this object will not be destroyed on start, making it a streaming object.")]
    public bool DontDestroy;

    public string PlayerTag;
    public GameObject PlayerObject = null;

    public Text HealthText = null;
    public Image HealthBar = null;

	// Use this for initialization
	void Start ()
    {
        if (DontDestroy)
            DontDestroyOnLoad(gameObject);

        PlayerObject = GameObject.FindGameObjectWithTag(PlayerTag);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerObject.GetComponent<Health>().HealthPoints <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(HealthText != null && HealthBar != null)
        {
            if(GameObject.FindGameObjectWithTag(PlayerTag) != null)
            {
                HealthBar.fillAmount = PlayerObject.GetComponent<Health>().HealthPoints / 10;
                HealthText.text = PlayerObject.GetComponent<Health>().HealthPoints.ToString("F0");
            }
            else if(GameObject.FindGameObjectWithTag(PlayerTag) == null)
            {
                HealthBar.fillAmount = 0;
                HealthText.text = "0";
            }
        }
	}
}
