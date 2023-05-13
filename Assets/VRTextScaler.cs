using UnityEngine;
using TMPro;

public class VRTextScaler : MonoBehaviour
{
    public float baseFontSize = 100f;
    public float distanceScaleFactor = 0.02f;
    private TMP_Text textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();
    }

    void Update()
    {
        float distanceToCamera = Vector3.Distance(Camera.main.transform.position, transform.position);
        float scaledFontSize = baseFontSize * distanceScaleFactor * distanceToCamera;
        textMeshPro.fontSize = scaledFontSize;
    }
}
