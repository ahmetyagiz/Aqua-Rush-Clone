using UnityEngine;
using UnityEngine.AI;

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

public class Character : MonoBehaviour
{
    private Animator _animator;
    private Transform _moveCellTarget;
    private Transform _moveLevelEndTarget;
    private NavMeshAgent _navMeshAgent;
    private CellEmptinessManager _cellEmptinessManager;
    private CheckSurroundingWithBox _checkSurroundingWithBox;

    private bool _isMovingToTarget;
    private bool _isMovingToLevelEnd;

    public ColorType colorType;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _cellEmptinessManager = GetComponent<CellEmptinessManager>();
        _checkSurroundingWithBox = GetComponent<CheckSurroundingWithBox>();

        _moveLevelEndTarget = SetLevelEndTarget();
    }

    void Update()
    {
        CharacterMovement();
        WakeUpCheck();
        MoveToLevelEndTarget();
    }

    void CharacterMovement()
    {
        if (_moveCellTarget != null && _isMovingToTarget)
        {
            _navMeshAgent.SetDestination(_moveCellTarget.position);
        }

        // Eðer NavMeshAgent hareket ediyorsa
        if (_navMeshAgent.enabled && !_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _isMovingToTarget)
        {
            // Eðer karakter hedefe ulaþtýysa
            if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                // Karakteri durdur
                CharacterReachedDestination();

                //Debug.Log("Karakter hedefe ulaþtý.");
            }
        }
    }

    public void StartMoveToTarget()
    {
        if (_checkSurroundingWithBox.IsSpaceFree() && FrontCellManager.Instance.IsAnyFrontCellEmpty())
        {
            _moveCellTarget = FrontCellManager.Instance.GetEmptyFrontCell();

            // Týkladýðým karakterin navmesh obstacle komponentini sil.
            _cellEmptinessManager.gridCell.GetComponent<NavMeshObstacle>().enabled = false;

            // Týkladýðým karakterin navmesh agentýný aç
            _navMeshAgent.enabled = true;

            GetComponent<BoxCollider>().enabled = false;
            _isMovingToTarget = true;
            _animator.SetTrigger("Run");
            _cellEmptinessManager.SetCellTagToEmpty();
        }
    }

    public void CharacterReachedDestination()
    {
        _navMeshAgent.isStopped = true;
        _isMovingToTarget = false;
        _animator.SetTrigger("Idle");
        transform.LookAt(transform.position + Vector3.back);
        MatchThreeChecker.Instance.AddCharacterToList(colorType, gameObject);
    }

    void WakeUpCheck()
    {
        if (_checkSurroundingWithBox.IsSpaceFree())
        {
            _animator.SetTrigger("WakeUp");
        }
    }

    public void MoveToLevelEndTargetTrigger()
    {
        _moveCellTarget.tag = "FrontCell_Empty";
        _animator.SetTrigger("Run");
        _navMeshAgent.stoppingDistance = 0.6f;
        _navMeshAgent.isStopped = false;
        _isMovingToLevelEnd = true;
    }

    Transform SetLevelEndTarget()
    {
        switch (colorType)
        {
            case ColorType.Blue:
                return GameObject.FindGameObjectWithTag("LevelEnd_Blue").transform;
            case ColorType.Green:
                return GameObject.FindGameObjectWithTag("LevelEnd_Green").transform;
            case ColorType.Orange:
                return GameObject.FindGameObjectWithTag("LevelEnd_Orange").transform;
            case ColorType.Purple:
                return GameObject.FindGameObjectWithTag("LevelEnd_Purple").transform;
            case ColorType.Red:
                return GameObject.FindGameObjectWithTag("LevelEnd_Red").transform;
            case ColorType.Yellow:
                return GameObject.FindGameObjectWithTag("LevelEnd_Yellow").transform;
            default:
                return null;
        }
    }

    void MoveToLevelEndTarget()
    {
        if (_moveLevelEndTarget != null && _isMovingToLevelEnd)
        {
            _navMeshAgent.SetDestination(_moveLevelEndTarget.position);
            //Debug.Log("Seviye sonuna gidiyorum");
        }

        // Eðer NavMeshAgent hareket ediyorsa
        if (_navMeshAgent.enabled && !_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _isMovingToLevelEnd)
        {
            // Eðer karakter hedefe ulaþtýysa
            if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                // Karakteri durdur
                CharacterReachedLevelEndDestination();

                //Debug.Log("Karakter kaydýraða ulaþtý.");
            }
        }
    }

    public void CharacterReachedLevelEndDestination()
    {
        //Debug.Log("Karakter kaydýraða ulaþtý");
        Destroy(gameObject);
    }
}