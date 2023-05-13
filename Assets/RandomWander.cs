using UnityEngine;

public class RandomWander : MonoBehaviour
{
    public float speed = 5.0f;
    public float maxX = 500.0f;
    public float maxY = 500.0f;
    public float minX = -500.0f;
    public float minY = -500.0f;
    public float height = 5.0f;
    public float changeDirectionInterval = 3.0f;

    public Vector3 planePosition;
    public Vector3 planeScale;


    private Vector3 targetPosition;

    void Start()
    {
        // Calculate plane size
        float planeWidth = planeScale.x * 10;
        float planeHeight = planeScale.z * 10;

        // Calculate plane boundaries
        float halfWidth = planeWidth / 2;
        float halfHeight = planeHeight / 2;
        minX = planePosition.x - halfWidth;
        maxX = planePosition.x + halfWidth;
        minY = planePosition.z - halfHeight;
        maxY = planePosition.z + halfHeight;

        SetNewTargetPosition();
        InvokeRepeating("SetNewTargetPosition", changeDirectionInterval, changeDirectionInterval);
    }


    void Update()
    {
        MoveToTarget();
    }

    void SetNewTargetPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minY, maxY);
        targetPosition = new Vector3(randomX, 5.0f, randomZ);
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
