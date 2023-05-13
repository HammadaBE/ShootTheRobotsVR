using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject gunModel;
    public float gunRange = 100.0f;
    public KeyCode shootButton = KeyCode.Mouse0;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the gun model
        GameObject gun = Instantiate(gunModel, transform.position, transform.rotation);
        // Set the gun as a child of the player object
        gun.transform.parent = transform;
        // Position the gun relative to the player
        gun.transform.localPosition = new Vector3(0.5f, -0.25f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootButton))
        {
            // Raycast forward from the gun's position
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, gunRange))
            {
                // If the ray hits a cube or sphere, destroy it
                if (hit.collider.CompareTag("Cube") || hit.collider.CompareTag("Sphere"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
