using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public List<GameObject> hearts;
    public static HealthManager instance;

    // Start is called before the first frame update
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Debug.LogError("Health Manager Instance Already Created");
        }
    }

    public void RemoveHeart()
    {
        GameObject lastHeart = hearts[hearts.Count - 1];
        lastHeart.SetActive(false);
        hearts.Remove(lastHeart);
        if (hearts.Count == 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
