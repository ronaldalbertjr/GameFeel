using UnityEngine;

public sealed class Cannon : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float instantiateOffset = 10.0f;
    public float shootImpulse = 30.0f;

    public Vector3 startingDirection = Vector3.left;

    

    private void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseDirection = Input.mousePosition - screenPosition;
        mouseDirection.z = 0.0f;

        var rotation = Quaternion.FromToRotation(startingDirection, mouseDirection);
        transform.localRotation = rotation;

        if( Input.GetMouseButtonDown(0))
        {
            Vector2 direction = ((Vector2)mouseDirection).normalized;
            Vector3 position = transform.position + (Vector3) direction * instantiateOffset;

            var bullet = Instantiate(bulletPrefab.gameObject, position, Quaternion.identity).GetComponent<Bullet>();
            bullet.impulse = direction * shootImpulse;
            Camera.main.GetComponent<CameraScript>().shakeDuration = 0.1f;
        }
    }


    
}
