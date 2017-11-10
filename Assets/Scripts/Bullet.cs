using UnityEngine;
using System.Collections;

public sealed class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRigidbody;
    Animator anim;
    public Vector2 impulse;
    public AnimationClip explosionAnim;

    private void Start()
    {
        bulletRigidbody.AddForce(impulse, ForceMode2D.Impulse);
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(transform.localScale.x <= 1)
        {
            transform.localScale *= 1.15f;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            StartCoroutine(ChangeTimeScale());
            Destroy(bulletRigidbody);
            anim.SetTrigger("Exploded");
            Camera.main.GetComponent<CameraScript>().shakeDuration = 0.05f;
            Invoke("DestroyBullet", explosionAnim.length);
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    } 
    
    IEnumerator ChangeTimeScale()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.05f);
        Time.timeScale = 1;
    }  
}
