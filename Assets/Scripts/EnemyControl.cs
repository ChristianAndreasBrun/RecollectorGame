using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState { Patroll, Follow, Alert, None }

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public Transform target;
    public NavMeshAgent agent;
    public Transform wayPoints;

    public int damage;
    public float attackDistance;
    int currentPoint;

    [Header("Estados")]
    public EnemyState state;
    public Vector3 lastPosPlayer;
    public bool isAttacking;
    public bool hasAttacked;

    [Header("Audio SFX")]
    public GameObject footStepsSFX;
    public AudioSource attackSFX;
    public AudioSource takeDamageSFX;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        footStepsSFX.GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        if (isAttacking || hasAttacked) return;

        switch (state)
        {
            case EnemyState.Patroll:
                agent.SetDestination(wayPoints.GetChild(currentPoint).position);
                anim.SetBool("enemyMoving", true);
                if (Vector3.Distance(transform.position, wayPoints.GetChild(currentPoint).position) < 1.5f)
                {
                    // Patrulla por puntos en orden
                    //currentPoint++;
                    //if (currentPoint >= wayPoints.childCount) currentPoint = 0;

                    // Patrulla de por puntos aleatorios
                    int randomPoint = Random.Range(0, wayPoints.childCount);
                    currentPoint = randomPoint;
                }
                break;

            case EnemyState.Follow:
                agent.SetDestination(target.position);
                anim.SetBool("enemyMoving", true);
                if (Vector3.Distance(transform.position, target.position) < attackDistance)
                {
                    StartCoroutine(cEnemyAttack());
                    footStepsSFX.GetComponent<AudioSource>().Stop();
                    hasAttacked = true;
                }
                break;

            case EnemyState.Alert:
                agent.SetDestination(lastPosPlayer);
                if (Vector3.Distance(transform.position, lastPosPlayer) < 1.5f)
                {
                    StartCoroutine(cChangeState(EnemyState.Patroll, 3));
                    state = EnemyState.None;
                }
                break;

            case EnemyState.None:
                anim.SetBool("enemyAttacking", false);
                break;
        }
    }


    IEnumerator cChangeState(EnemyState state, float time)
    {
        anim.SetBool("enemyMoving", false);
        yield return new WaitForSeconds(time);
        this.state = state;
    }

    IEnumerator cEnemyAttack()
    {
        agent.speed = 0;
        anim.SetBool("enemyAttacking", true);
        isAttacking = true;
        attackSFX.Play();

        yield return new WaitForSeconds(1f);

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            PlayerControl player = playerObject.GetComponent<PlayerControl>();
            if (player != null)
            {
                takeDamageSFX.Play();
                player.TakeDamage(damage);
            }
        }

        anim.SetBool("enemyAttacking", false);

        yield return new WaitForSeconds(5f);

        isAttacking = false;
        hasAttacked = false;
        state = EnemyState.None;
    }
}
