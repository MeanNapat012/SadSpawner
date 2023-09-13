using UnityEngine;

namespace SuperGame.SubwaySurfer2D
{
    public class PlayerTakeDamage : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Health>().TakeDamage();
                Destroy(this.gameObject);
            }
        }
    }
}
