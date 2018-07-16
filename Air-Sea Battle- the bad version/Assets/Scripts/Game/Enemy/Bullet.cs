using UnityEngine;

public class Bullet : MonoBehaviour {
    public bool playerOne;
    public float speed;
    void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }
}
