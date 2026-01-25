using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f;

   void Update()
{
    transform.Translate(Vector3.up * speed * Time.deltaTime);

    if (transform.position.y > 6f)
    {
        Destroy(gameObject);
    }
}

}
