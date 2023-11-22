using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCharacter : MonoBehaviour
{
    public GameObject player;
    public GameObject DialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        DialogueUI = GameObject.Find("Dialogue UI");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (player != null)
            {
                Collider2D playerCollider = player.GetComponent<Collider2D>();
                if (playerCollider != null && playerCollider.IsTouching(GetComponent<Collider2D>()))
                {
                    if(DialogueUI == null){
                        DialogueUI.SetActive(true);
                        Debug.Log("DialogueUI activated");
                    }
                }
            }

        }
    }
}
