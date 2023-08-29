using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform[] pathPoints;
    public float movementSpeed = 5.0f;

    private int currentPointIndex = 0;
    private float journeyDistance;
    private float startTime;

    private void Start()
    {
        if (pathPoints.Length > 1)
        {
            journeyDistance = Vector3.Distance(pathPoints[currentPointIndex].position, pathPoints[currentPointIndex + 1].position);
            startTime = Time.time;
        }
        else
        {
            enabled = false;
        }
    }

    private void Update()
    {
        if (currentPointIndex < pathPoints.Length - 1)
        {
            float distanceCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distanceCovered / journeyDistance;

            transform.position = Vector3.Lerp(pathPoints[currentPointIndex].position, pathPoints[currentPointIndex + 1].position, fractionOfJourney);

            if (fractionOfJourney >= 1.0f)
            {
                currentPointIndex++;
                if (currentPointIndex < pathPoints.Length - 1)
                {
                    journeyDistance = Vector3.Distance(pathPoints[currentPointIndex].position, pathPoints[currentPointIndex + 1].position);
                    startTime = Time.time;
                }
            }
        }
        else
        {

        }
    }
}
