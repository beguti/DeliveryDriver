using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay=0.5f;

    [SerializeField] Color32 hasColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    bool hasPackage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("What was that?!");
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            hasColor = other.GetComponent<SpriteRenderer>().color;
            spriteRenderer.color = hasColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color=noColor;
        }
    }
}

