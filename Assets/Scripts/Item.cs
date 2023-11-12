using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    private float randomValue;
    // Start is called before the first frame update
    void Start()
    {
        randomValue = Random.Range(0, 50);
    }

    public float getValue(){
        return randomValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Collider2D playerCollider = player.GetComponent<Collider2D>();

                if (playerCollider != null && playerCollider.IsTouching(GetComponent<Collider2D>()))
                {
                    Destroy(GetComponent<Collider2D>().gameObject);
                    Debug.Log("Item value " + randomValue);
                }
            }

        }

    }

}
