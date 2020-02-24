using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class GroundCheck : MonoBehaviour
    {
        GameObject Player;
        void Start()
        {
            Player = gameObject.transform.parent.gameObject;
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Ground")
            {
                Player.GetComponent<PlayerMovement>().isGrounded = true;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.tag == "Ground")
            {
                Player.GetComponent<PlayerMovement>().isGrounded = false;
            }
        }
    }
}
