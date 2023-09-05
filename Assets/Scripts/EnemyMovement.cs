using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform[] startPoints;
    public GameObject[] attackPoints;
    private GameObject targetObject;
    private Transform targetPoint;

    private Rigidbody rb;

    private AudioSource audioSource;
    public AudioClip[] footStepSounds;
    public AudioClip[] attackSounds;
    public float stepFrequency;
    private float lastStepTime = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        transform.position = startPoints[Random.Range(0, startPoints.Length)].position;
        targetObject = attackPoints[Random.Range(0, attackPoints.Length)];
        targetPoint = targetObject.transform;
        //타켓이 이미 acitve일 경우 spawner에서 생성 x
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.5f)
        {
            EnemyHitPoints enemyHitPoints = targetObject.GetComponent<EnemyHitPoints>();
            enemyHitPoints.EnemyArrived = true;
            enemyHitPoints.EnemyAttack();
            gameObject.SetActive(false);
        }
        else
        {
            Vector3 moveDirection = (targetPoint.position - transform.position).normalized;

            transform.forward = moveDirection;
            Vector3 velocity = moveDirection * moveSpeed;
            rb.velocity = velocity;

            if (Time.time > lastStepTime + stepFrequency)
            {
                lastStepTime = Time.time;
                audioSource.PlayOneShot(footStepSounds[Random.Range(0, footStepSounds.Length)]);
            }
        }
    }
}
