using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    public float jumpForce = 10f; 
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;
    public AudioSource bounce,Point;
    public GameObject masterScript;
    
    public Collider2D ball,Finish;
    bool finish = true;
   
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
        finish = Physics2D.IsTouching(ball,Finish);

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;//kecepatan player   
            bounce.Play(); 
        }

        if(finish)
        {
            Debug.Log("YOU WIN");
            SceneManager.LoadScene("WinScene");
        }


    }

    // public void CompleteGame()
    // {
    //     Debug.Log("YOU WON");
    // }
    void OnTriggerEnter2D (Collider2D col) //waktu bola nabrak roda
    {   
        if (col.tag == "ColorChanger") //ubah warna bola keetika menabrak pengubahwarna
        {
            SetRandomColor();
            Destroy(col.gameObject); //meghilangkan pengubahWarna sesuda di tabrak
            return;
        }

        if (col.tag == "Lollipop")
        {
            Destroy(col.gameObject);
            Point.Play();
            masterScript.GetComponent<ScoringScript>().UpdateScore(col.tag);
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
