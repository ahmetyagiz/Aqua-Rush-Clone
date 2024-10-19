using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public enum ColorType
    {
        None,
        Blue,
        Green,
        Orange,
        Purple,
        Red,
        Yellow,
    }

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private bool _isMovingToTarget;
    private Transform _moveCellTarget;

    public ColorType colorType;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_moveCellTarget != null && _isMovingToTarget)
        {
            _navMeshAgent.SetDestination(_moveCellTarget.position);
        }

        // E�er NavMeshAgent hareket ediyorsa
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _isMovingToTarget)
        {
            // E�er karakter hedefe ula�t�ysa
            if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                // Karakteri durdur
                CharacterReachedDestination();

                //Debug.Log("Karakter hedefe ula�t�.");
            }
        }
    }

    public void StartMoveToTarget()
    {
        _moveCellTarget = FrontCellManager.Instance.GetEmptyFrontCell();
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