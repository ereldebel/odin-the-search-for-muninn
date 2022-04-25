using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        var pos = transform.position; 
        pos.x += Time.deltaTime * speed;
        transform.position = pos;
    }

    private void OnBecameInvisible()
    {
        var pos = transform.position;
        pos.x = -19.1f;
        transform.position = pos;
    }
}
