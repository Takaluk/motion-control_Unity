using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Transform targetPoint;
    private int targetIndex = 1;
    private Rigidbody rb;
    public Transform[] route;
    private AudioSource audioSource;
    public AudioClip[] footStepSounds;
    public float stepFrequency;
    private float lastStepTime = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        transform.position = route[0].position;
        targetPoint = route[1];
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, targetPoint.position) < 10f)
        {
            targetIndex++;
            if (targetIndex >= route.Length)
            {
                Attack();
            }
            else
            {
                targetPoint = route[targetIndex];
            }
        }

        Vector3 moveDirection = (targetPoint.position - transform.position).normalized;
        moveDirection.y = 0;

        transform.forward = moveDirection;
        Vector3 velocity = moveDirection * moveSpeed;
        rb.velocity = velocity;

        if(Time.time > lastStepTime + stepFrequency)
        {
            lastStepTime = Time.time;
            audioSource.PlayOneShot(footStepSounds[Random.Range(0, footStepSounds.Length)]);
        }
    }

    private void Attack()
    {
        gameObject.SetActive(false);
    }
}
