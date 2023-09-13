using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperGame{
public class ShieldEffect : MonoBehaviour
{
   [SerializeField] Color Shieldcolor = Color.blue;

        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag == "Player")
            {
                col.gameObject.GetComponent<Health>().PlayerShield();
            }
            Destroy(gameObject);
        }
        //  IEnumerator ChangeColorTemp(SpriteRenderer spriteRenderer)
        // {
        //     Color originalColor = spriteRenderer.color;
        //     spriteRenderer.color = Shieldcolor;
        //     yield return new WaitForSeconds(1.5f); 
        //     spriteRenderer.color = originalColor;
        // }
        // void ShieldColor(SpriteRenderer spriteRenderer)
        // {
        //     StartCoroutine(ChangeColorTemp(spriteRenderer));
        // }
}
}