using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    public float jumpForce = 10f; 
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;
    public AudioSource bounce;

    public Color colorBiru;
    public Color colorKuning;
    public Color colorUngu;
    public Color colorPink;
    void Start() //set warna terakhir yg di tabrak bola
    {
        SetRandomColor(); 

    } 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;//kecepatan player   
            bounce.Play(); 
        }
    }

    void OnTriggerEnter2D (Collider2D col) //waktu bola nabrak roda
    {   
        if (col.tag == "ColorChanger") //ubah warna bola keetika menabrak pengubahwarna
        {
            SetRandomColor();
            Destroy(col.gameObject); //meghilangkan pengubahWarna sesuda di tabrak
            return;
        }

        if (col.tag != currentColor)//==: pass anything happen
        {
            Debug.Log("GAME OVER!");
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void SetRandomColor () //fungsi warna random
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Biru";
                sr.color = colorBiru; //color ball
                break;
            case 1:
                currentColor = "Kuning";
                sr.color = colorKuning;
                break;
            case 2:
                currentColor = "Ungu";
                sr.color = colorUngu;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }
}
