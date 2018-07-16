using UnityEngine;

public class Gun_Rotation : MonoBehaviour {

    public float speed;
    float rotZ;

    void Update () {

        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding Angle of mouse to camera from bottom left
        Quaternion rotateTowards = Quaternion.Euler(0f, 0f, Mathf.Clamp(rotZ,10f,170f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTowards, speed * Time.deltaTime);
    }
}
