/*
 * Author: Tan Jing Ren, Mattias
 * Date: 26 June 2024
 * Description:  Manages enemy AI behavior including patrolling, chasing, attacking the player, and taking damage.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder;

public class EnemyAi : MonoBehaviour
{
    /// <summary>
    /// The NavMeshAgent component attached to the enemy.
    /// </summary>
    public NavMeshAgent agent;

    /// <summary>
    /// The player's transform.
    /// </summary>
    public Transform player;

    /// <summary>
    /// Layers considered as ground and player.
    /// </summary>
    public LayerMask whatIsGround, whatIsPlayer;

    /// <summary>
    /// The health of the enemy.
    /// </summary>
    public float health;

    // Patrolling
    /// <summary>
    /// The point to walk to during patrolling.
    /// </summary>
    public Vector3 walkPoint;
    private bool walkPointSet;
    /// <summary>
    /// The range within which the walk point is set.
    /// </summary>
    public float walkPointRange;

    // Attacking
    /// <summary>
    /// The time between attacks.
    /// </summary>
    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    // States of the AI
    /// <summary>
    /// The sight range of the enemy.
    /// </summary>
    public float sightRange;

    /// <summary>
    /// The attack range of the enemy.
    /// </summary>
    public float attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Shooting
    /// <summary>
    /// The bullet prefab to shoot at the player.
    /// </summary>
    public GameObject enemyBullet;

    /// <summary>
    /// The point from which the bullet is spawned.
    /// </summary>
    public Transform spawnPoint;

    /// <summary>
    /// The speed at which the bullet travels.
    /// </summary>
    public float enemySpeed;

    /// <summary>
    /// Initializes the enemy AI, setting the player and NavMeshAgent references.
    /// </summary>
    private void Awake()
    {
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Called once per frame to update the enemy's behavior.
    /// </summary>
    void Update()
    {
        // Check if player is in sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    /// <summary>
    /// Handles the patrolling behavior of the enemy.
    /// </summary>
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        // walkpoints
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walk point reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    /// <summary>
    /// Searches for a walk point within the specified range.
    /// </summary>
    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    /// <summary>
    /// Chases the player by setting the agent's destination to the player's position.
    /// </summary>
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    /// <summary>
    /// Handles the attack behavior of the enemy.
    /// </summary>
    private void AttackPlayer()
    {
        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        // Rotate as it attacks
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        if (!alreadyAttacked)
        {
            // Attack code here
            ShootAtPlayer();
            // End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    /// <summary>
    /// Shoots a bullet at the player.
    /// </summary>
    private void ShootAtPlayer()
    {
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        Vector3 direction = (player.position - spawnPoint.position).normalized;
        bulletRig.AddForce(spawnPoint.forward * enemySpeed, ForceMode.Impulse);
        Destroy(bulletObj, 5f);
    }

    /// <summary>
    /// Resets the attack status to allow for the next attack./time between attacks
    /// </summary>
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    /// <summary>
    /// Applies damage to the enemy.
    /// </summary>
    /// <param name="damage">The amount of damage to apply.</param>
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    /// <summary>
    /// Destroys the enemy game object.
    /// </summary>
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
