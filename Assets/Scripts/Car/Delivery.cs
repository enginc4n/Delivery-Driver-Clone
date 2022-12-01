using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delayTime = 0.5f;


    [SerializeField] Color32 hasPackageColor = new Color32();
    [SerializeField] Color32 hasNoPackageColor = new Color32();

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Driver.moveSpeed = 10f;
    }

    private void OnTriggerEnter2D(Collider2D gameObject)
    {

        // if we got the package
        if (gameObject.tag == "Package" && !hasPackage)
        {
            Debug.Log("Picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(gameObject.gameObject, delayTime);

        }

        // if we delivered the package
        if (gameObject.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered!");
            spriteRenderer.color = hasNoPackageColor;
            hasPackage = false;
        }

        //if we pass through speed boost
        if (gameObject.tag == "SpeedBoost")
        {
            Driver.moveSpeed = 25f;
        }
    }
}
