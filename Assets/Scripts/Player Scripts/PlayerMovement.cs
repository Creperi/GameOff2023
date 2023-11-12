using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Item item;
    [SerializeField] private TMP_Text PressButtonText;
    [SerializeField] float speed = 4f;
    private Vector2 moveDirection;
    private PlayerAnimation animations;
    public Rigidbody2D rb;
    List<float>CollectedItemsValues = new List<float>();

    void Start() 
    {
        animations = GetComponent<PlayerAnimation>();
    }
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        if (moveDirection.normalized.y > 0.75f)
            animations.ChangeAnimationState(PlayerAnimation.AnimationState.RUNNING_UP);
        else if (moveDirection.normalized.y < -0.75f)
            animations.ChangeAnimationState(PlayerAnimation.AnimationState.IDLE);
        else if (moveDirection.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            animations.ChangeAnimationState(PlayerAnimation.AnimationState.RUNNING_HORIZONTAL);
        }
        else if (moveDirection.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            animations.ChangeAnimationState(PlayerAnimation.AnimationState.RUNNING_HORIZONTAL);
        }
        else
            animations.ChangeAnimationState(PlayerAnimation.AnimationState.IDLE);

    }

    void FixedUpdate()
    {
        print(moveDirection.normalized);
        rb.MovePosition(rb.position + moveDirection.normalized * (speed * Time.fixedDeltaTime));
    }

    void OnTriggerEnter2D(Collider2D collider){

        if(collider.gameObject.CompareTag("Item")){
            Debug.Log("Press E to pick up");
            Item itemScript = collider.gameObject.GetComponent<Item>();
            PressButtonText.text = "Press E to pick up item";
            if(Input.GetKeyDown(KeyCode.E)){
                CollectedItemsValues.Add(itemScript.getValue());
                Debug.Log("Item added ");
            }
        }
        else if(collider.gameObject.CompareTag("Scale")){
            Debug.Log("Press SpaceBar to scale");
            PressButtonText.text = "Press SpaceBar to scale";
            if(Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene("WeightScaleScene");
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        PressButtonText.text = "";
    }
}
