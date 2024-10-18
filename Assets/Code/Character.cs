using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public enum ColorType
    {
        Green,
        Blue,
        Red,
    }

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private bool _isMovingToTarget;
    private bool _isTargetReached;

    [SerializeField] private ColorType colorType;
    [SerializeField] private Transform Debug_TARGET;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Debug_TARGET != null && _isMovingToTarget)
        {
            _navMeshAgent.SetDestination(Debug_TARGET.position);
        }

        // E�er NavMeshAgent hareket ediyorsa
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _isMovingToTarget)
        {
            // E�er karakter hedefe ula�t�ysa
            if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                // Karakteri durdur
                CharacterReachedDestination();

                Debug.Log("Karakter hedefe ula�t�.");
            }
        }
    }

    public void StartMoveToTarget()
    {
        _isMovingToTarget = true;
        _animator.SetTrigger("WakeUp");
        _animator.SetTrigger("Run");
    }

    public void CharacterReachedDestination()
    {
        _navMeshAgent.isStopped = true;
        _isMovingToTarget = false;
        _animator.SetTrigger("Idle");
        transform.LookAt(transform.position + Vector3.back);
    }
}