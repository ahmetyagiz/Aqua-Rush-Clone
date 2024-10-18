using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    //public GridManager gridManager;
    //public int posX, posY; // Karakterin grid üzerindeki pozisyonu
    //public Color openColor; // Eðer çevresi açýksa bu renge deðiþ
    //public Color closedColor; // Eðer çevresi kapalýysa bu renge deðiþ
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

    //    // Sað, Sol, Ön, Arka ve Çapraz yönleri kontrol et
    //    if (gridManager.IsCellEmpty(posX + 1, posY)) isSurrounded = false; // Sað
    //    if (gridManager.IsCellEmpty(posX - 1, posY)) isSurrounded = false; // Sol
    //    if (gridManager.IsCellEmpty(posX, posY + 1)) isSurrounded = false; // Ön
    //    if (gridManager.IsCellEmpty(posX, posY - 1)) isSurrounded = false; // Arka
    //    if (gridManager.IsCellEmpty(posX + 1, posY + 1)) isSurrounded = false; // Sað-Ön çapraz
    //    if (gridManager.IsCellEmpty(posX - 1, posY + 1)) isSurrounded = false; // Sol-Ön çapraz
    //    if (gridManager.IsCellEmpty(posX + 1, posY - 1)) isSurrounded = false; // Sað-Arka çapraz
    //    if (gridManager.IsCellEmpty(posX - 1, posY - 1)) isSurrounded = false; // Sol-Arka çapraz

    //    // Rengi güncelle
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

        // Karakterin hedefe doðru hareket etmesini saðla

    }

    void Update()
    {
        if (Debug_TARGET != null && isMovingToTarget)
        {
            _navMeshAgent.SetDestination(Debug_TARGET.position);
        }

        // Eðer NavMeshAgent hareket ediyorsa
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && isMovingToTarget)
        {
            // Eðer karakter hedefe ulaþtýysa
            if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
            {
                // Karakteri durdur
                CharacterReachedDestination();

                Debug.Log("Karakter hedefe ulaþtý.");
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