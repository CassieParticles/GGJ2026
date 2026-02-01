using UnityEngine;

public class GroupMemberScript : MonoBehaviour
{

    [SerializeField] float idleSpeed = 5f;
    [SerializeField] float idleSpeedVariation = 0.5f;
    [SerializeField] float idleAmplitudeX = 5f;
    [SerializeField] float idleAmplitudeY = 5f;
    float idleTimer;

    Vector3 baseScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        idleTimer = Random.value * 10;
        idleSpeed = idleSpeed + (Random.value - 0.5f) * idleSpeedVariation * 2;
        
        baseScale = transform.localScale;

        if (gameObject.GetComponentInParent<GroupBehaviour>() != null) {
            GetComponent<SpriteRenderer>().sprite = gameObject.GetComponentInParent<GroupBehaviour>().GetAssets();
        }


    }

    // Update is called once per frame
    void Update()
    {
        idleTimer += Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Cos(idleTimer * idleSpeed) * idleAmplitudeX);
        transform.localScale = new Vector3(baseScale.x, baseScale.y + Mathf.Sin(idleTimer * 2 * idleSpeed + 0.5f * Mathf.PI) * 0.01f * idleAmplitudeY, 1);
    }
}
