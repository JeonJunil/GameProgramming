using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    private enum State { Idle, Wander, Chase }
    private State currentState;

    private NavMeshAgent agent;
    private Transform mainBase;

    public float idleDuration = 2f; // Idle 상태 유지 시간
    public float wanderRadius = 10f; // Wander 상태에서 이동할 반경
    public float wanderDuration = 3f; // Wander 상태 유지 시간

    private float stateTimer;

    void Start()
    {
        // 초기 상태를 Idle로 설정
        currentState = State.Idle;

        // NavMeshAgent 컴포넌트 가져오기
        agent = GetComponent<NavMeshAgent>();

        // Main Base 오브젝트 찾기
        mainBase = GameObject.FindGameObjectWithTag("MainBase").transform;

        // Idle 상태 타이머 초기화
        stateTimer = idleDuration;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;

            case State.Wander:
                Wander();
                break;

            case State.Chase:
                ChaseMainBase();
                break;
        }
    }

    private void Idle()
    {
        // Idle 상태에서 일정 시간이 지나면 Wander 상태로 전환
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0)
        {
            currentState = State.Wander;
            stateTimer = wanderDuration;
        }
    }

    private void Wander()
    {
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0)
        {
            // Wander 시간이 끝나면 Main Base를 추적하는 Chase 상태로 전환
            currentState = State.Chase;
        }
        else
        {
            // 적이 랜덤 위치로 이동하도록 설정
            if (!agent.hasPath)
            {
                Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
                randomDirection += transform.position;
                NavMeshHit navHit;
                NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, NavMesh.AllAreas);
                agent.SetDestination(navHit.position);
            }
        }
    }

    private void ChaseMainBase()
    {
        if (mainBase != null && agent != null)
        {
            agent.SetDestination(mainBase.position);
        }
    }
}
