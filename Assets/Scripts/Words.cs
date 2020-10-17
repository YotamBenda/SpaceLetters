using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Words : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;

    private float tempSpeed;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -900)
        {
            Destroy(gameObject);
        }
    }

}
