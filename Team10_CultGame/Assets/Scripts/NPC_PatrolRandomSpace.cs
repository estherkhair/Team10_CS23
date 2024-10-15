using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events; 

public class NPC_PatrolRandomSpace : MonoBehaviour {

       public GameObject sheepStage1;
       public GameObject sheepStage2; 
       
       public float speed = 10f;
       private float waitTime;
       public float startWaitTime = 2f;

       public Transform moveSpot;
       public float minX;
       public float maxX;
       public float minY;
       public float maxY;

       public bool isTamed = false; 
       public float timeToTame = 0.5f;

       public bool followPlayer = true;
       private GameObject player;
       private Vector2 playerPos;
       private float distToPlayer;
       public float followDistance = 5f;
       public float startFollowDistance = 5f;
       public float moveSpeed = 5f;
       public float topSpeed = 10f;
       private float scaleX;

       void Start(){
              player = GameObject.FindWithTag("Player");
              waitTime = startWaitTime;
              float randomX = Random.Range(minX, maxX);
              float randomY = Random.Range(minY, maxY);
              moveSpot.position = new Vector2(randomX, randomY);
              

              sheepStage1.SetActive(true);
              sheepStage2.SetActive(false);
              scaleX = gameObject.transform.localScale.x;
              followDistance = Random.Range(1f, 2f);
              startFollowDistance = followDistance + 1f;
              moveSpeed = Random.Range((topSpeed * 0.7f), topSpeed);
       }

       void FixedUpdate(){
              if (!isTamed) {
              transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

              if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f){
                     if (waitTime <= 0){
                            float randomX = Random.Range(minX, maxX);
                            float randomY = Random.Range(minY, maxY);
                            moveSpot.position = new Vector2(randomX, randomY);
                            waitTime = startWaitTime;
                     } else {
                            waitTime -= Time.deltaTime;
                     }
              }
              }
              else if (isTamed) {
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

                     if (player.transform.position.x > gameObject.transform.position.x){
                                gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
                        } else {
                                gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
              }
       }
       }
       }
       /* IEnumerator toTame() {
              sheepStage1.SetActive(false);
              sheepStage2.SetActive(true);
              yield return new WaitForSeconds(timeToTame);
       
       } */ 

       public void TameSheep() {
              isTamed = true; 
              sheepStage1.SetActive(false);
              sheepStage2.SetActive(true);
       }
}