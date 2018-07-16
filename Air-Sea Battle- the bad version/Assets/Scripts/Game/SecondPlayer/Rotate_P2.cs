using UnityEngine;

public class Rotate_P2 : MonoBehaviour {

    public float speed;
    float rotZ;
    float max = 170, min = 10;

    void Update () {

        Vector3 rotation = transform.rotation.eulerAngles;
        rotZ = rotation.z;
        Mathf.Clamp(rotZ, min, max);

        if (Input.GetKey(KeyCode.G))
        {
            if (rotZ <= max)
            {
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.H))
        {
            if (rotZ >= min)
            {
                transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}
