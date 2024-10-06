using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Follower : MonoBehaviour {
       //this script offers basic flocking behavior for friendly NPCs to follow the player
       //commented-out are functions for followers to help attack enemies if the player attacks

       //private Animator anim;

//Follow Player
       private GameObject player;
       private Vector2 playerPos;
       private float distToPlayer;
       public float startFollowDistance = 5f; //Follow Player when further than this distance
       public float followDistance = 2f; //Stop moving towards player when at this distance
       public float moveSpeed = 5f;
       public float topSpeed = 10f;
       private float scaleX;
       //public Vector2 offsetFollow;
       public bool followPlayer = true;


       void Start(){
              //anim = gameObject.GetComponentInChildren<Animator>();
              player = GameObject.FindWithTag("Player");
              followDistance = Random.Range(1f, 2f);
              startFollowDistance = followDistance + 1f;
              moveSpeed = Random.Range((topSpeed * 0.7f), topSpeed);
              scaleX = gameObject.transform.localScale.x;
       }


        void FixedUpdate(){
                //FOLLOW PLAYER
               if ((followPlayer) && (player != null)){
                      playerPos = player.transform.position;
                      distToPlayer = Vector2.Distance(transform.position, playerPos);

                      //Retreat from Player
                      if (distToPlayer <= followDistance){
                                transform.position = Vector2.MoveTowards (transform.position, playerPos, -moveSpeed * Time.deltaTime);
                                //anim.SetBool("Walk", true);
                      }

                      // Stop following Player
                      if ((distToPlayer > followDistance) && (distToPlayer < startFollowDistance)){
                                transform.position = this.transform.position;
                                //anim.SetBool("Walk", false);
                      }

                      // Follow Player
                      else if (distToPlayer >= startFollowDistance){
                                transform.position = Vector2.MoveTowards (transform.position, playerPos, moveSpeed * Time.deltaTime);
                                //anim.SetBool("Walk", true);
                      }

                      // Turn follower toward player (good for bipedal characters)
                      /*
                       if (player.transform.position.x > gameObject.transform.position.x){
                                gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
                        } else {
                                gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
                        }
                        */

                        // Rotate to face player (good for swimming / flying followers)
                        Vector2 direction = (playerPos - (Vector2)transform.position).normalized;
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        float offset = 90f;
                        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
              }
        //end bracket of FixedUpdate:
        }


        // DISPLAY the range of enemy's attack when selected in the Editor
        void OnDrawGizmos(){
                Gizmos.DrawWireSphere(transform.position, followDistance);
        }

}
