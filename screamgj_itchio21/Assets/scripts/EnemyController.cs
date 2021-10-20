using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 12.5f;
    public Transform[] waypoints;
    public float waypointIndexAddDistance = 1f;
    Transform playerTarget;
    NavMeshAgent agent;
    private int waypointIndex;
    private float waypointDist;
    private bool isSearchingLastPlayerPos;
    Vector3 lastPlayerPos;
    public GameObject playerFadeAnimation;
    public GameObject enemySFXFadeAnimationNear;
    public GameObject enemySFXFadeAnimationAway;

    void Start () {
        playerTarget = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        waypointIndex = 0;
    }

    void Update () {
        float playerDistance = Vector3.Distance(playerTarget.position, transform.position);
        float lastPlayerPosDistance = Vector3.Distance(lastPlayerPos, transform.position);

        if (playerDistance <= lookRadius) {
            lastPlayerPos = playerTarget.position;

            agent.SetDestination(playerTarget.position);
            isSearchingLastPlayerPos = true;
        }
        else {
            if (lastPlayerPosDistance < 1f) {
                isSearchingLastPlayerPos = false;
            }       
        }
        
        if (!isSearchingLastPlayerPos) {
            if (waypointIndex >= waypoints.Length) {
                    waypointIndex = 0;
            }
            Patrol ();
            increaseIndexNumber ();
        }
        else {
                agent.SetDestination(lastPlayerPos);
            }
    }

    void Patrol () {
        agent.SetDestination(waypoints[waypointIndex].position);
    }

    void increaseIndexNumber () {
        waypointDist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        if (waypointDist < waypointIndexAddDistance) {
            waypointIndex += 1;
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player")) {
            playerFadeAnimation.GetComponent<PlayerFadeAnimationController>().fade();
            enemySFXFadeAnimationNear.GetComponent<EnemyFadeAnimationController>().enemyFade();
            enemySFXFadeAnimationAway.GetComponent<EnemyFadeAnimationController>().enemyFade();
        }
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
