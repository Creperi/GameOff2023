using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeightScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Collider2D playerCollider = player.GetComponent<Collider2D>();

                if (playerCollider != null && playerCollider.IsTouching(GetComponent<Collider2D>()))
                {
                    SceneManager.LoadScene("WeightScaleScene");
                }
            }

        }
    }

    void WeightEvidence(){
        GameObject.Find("Menu Canvas").SetActive(false);
        Debug.Log("Weight Evidence");
    }
}
