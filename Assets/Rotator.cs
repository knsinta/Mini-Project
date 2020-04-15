using UnityEngine;

public class Rotator : MonoBehaviour
{
   
    public float speed = 100f;//kecepatan rotasi,100 drjt/dtk
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime); //dt: to compire previous frame to current frame

    }
}
