using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.5f;
    Rigidbody rb;
    private ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }


    public enum ObjectType
    {
        None,
        Cube,
        Sphere
    }

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private ObjectType GetDestroyedObjectType(GameObject other)
    {
        if (other.CompareTag("Cube"))
        {
            return ObjectType.Cube;
        }
        else if (other.CompareTag("Sphere"))
        {
            return ObjectType.Sphere;
        }
        return ObjectType.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube") || other.gameObject.CompareTag("Sphere"))
        {
            Debug.Log("Bullet collided with a Cube or Sphere: " + other.gameObject.name);

            ObjectType destroyedObjectType = GetDestroyedObjectType(other.gameObject);

            Destroy(other.gameObject);

            if (destroyedObjectType == ObjectType.Cube)
            {
                scoreManager.UpdateScore(1);
            }
            else if (destroyedObjectType == ObjectType.Sphere)
            {
                scoreManager.UpdateScore(2);
            }

            Destroy(gameObject);
        }
    }
}
