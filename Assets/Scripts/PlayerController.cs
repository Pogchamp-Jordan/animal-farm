using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float xRange = 20;
    public GameObject projectile;
    private float horizontalInput;
    private Animator anim;
    public ParticleSystem deathParticleEffect;
    public AudioClip projectileSound;
    public string endSceneName;

    private float timeForSceneTransition = 2;
  

    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }

        if (horizontalInput == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(projectileSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("animal") == true)
        {
            HealthManager.instance.RemoveHeart();
        }
    }

    public void Die()
    {
        
        Instantiate(deathParticleEffect, transform.position, transform.rotation);
        ScoreManager.instance.StopGame();
        StartCoroutine(LoadEndScene());
    }

    private IEnumerator LoadEndScene()
    {
        yield return new WaitForSeconds(timeForSceneTransition);

        SceneManager.LoadScene(endSceneName);
        ScoreManager.instance.HideText();
        ScoreManager.instance.ShowEndScreenText();
    }
}
