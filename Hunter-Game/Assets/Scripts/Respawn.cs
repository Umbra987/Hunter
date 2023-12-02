using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;
    public Animator animator;
    public BarraDeVida vida;

    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX")!= 0)
        {
            transform.position = new UnityEngine.Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositiony"));   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.GetFloat("checkPointPositionX", x);
        PlayerPrefs.GetFloat("checkPointPositionY", y);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            vida.vidaactual -= 20;
            animator.SetTrigger("Hurt");

        }
        if (vida.vidaactual <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
