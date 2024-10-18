using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    //public GridManager gridManager;
    //public int posX, posY; // Karakterin grid �zerindeki pozisyonu
    //public Color openColor; // E�er �evresi a��ksa bu renge de�i�
    //public Color closedColor; // E�er �evresi kapal�ysa bu renge de�i�
    //public Renderer characterRenderer;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform Debug_TARGET;
    private bool isMovingToTarget;
    private bool isTargetReached;

    //void Start()
    //{
    //    UpdateCharacterColor();
    //}

    //void UpdateCharacterColor()
    //{
    //    bool isSurrounded = true;

    //    // Sa�, Sol, �n, Arka ve �apraz y�nleri kontrol et
    //    if (gridManager.IsCellEmpty(posX + 1, posY)) isSurrounded = false; // Sa�
    //    if (gridManager.IsCellEmpty(posX - 1, posY)) isSurrounded = false; // Sol
    //    if (gridManager.IsCellEmpty(posX, posY + 1)) isSurrounded = false; // �n
    //    if (gridManager.IsCellEmpty(posX, posY - 1)) isSurrounded = false; // Arka
    //    if (gridManager.IsCellEmpty(posX + 1, posY + 1)) isSurrounded = false; // Sa�-�n �apraz
    //    if (gridManager.IsCellEmpty(posX - 1, posY + 1)) isSurrounded = false; // Sol-�n �apraz
    //    if (gridManager.IsCellEmpty(posX + 1, posY - 1)) isSurrounded = false; // Sa�-Arka �apraz
    //    if (gridManager.IsCellEmpty(posX - 1, posY - 1)) isSurrounded = false; // Sol-Arka �apraz

    //    // Rengi g�ncelle
    //    if (isSurrounded)
    //    {
    //        characterRenderer.material.color = closedColor;
    //    }
    //    else
    //    {
    //        characterRenderer.material.color = openColor;
    //    }
    //}

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        // Karakterin hedefe do�ru hareket etmesini sa�la

    }

    void Update()
    {
        if (Debug_TARGET != null && isMovingToTarget)
        {
            _navMeshAgent.SetDestination(Debug_TARGET.position);
        }

        // E�er NavMeshAgent hareket ediyorsa
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && isMovingToTarget)
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
        isMovingToTarget = true;
        _animator.SetTrigger("WakeUp");
        _animator.SetTrigger("Run");
    }

    public void CharacterReachedDestination()
    {
        _navMeshAgent.isStopped = true;
        isMovingToTarget = false;
        _animator.SetTrigger("Idle");
        transform.LookAt(transform.position + Vector3.back);
    }
}