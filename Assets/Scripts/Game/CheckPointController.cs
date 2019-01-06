using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CheckPointController : MonoBehaviour
    {
        [SerializeField] private Sprite spriteDonePoint;

        public bool isFull;
        
        // Start is called before the first frame update
        void Start()
        {
            isFull = false;
        }

        
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (!other.tag.Equals("Box")) return;
            
            GetComponent<SpriteRenderer>().sprite = spriteDonePoint;
            isFull = true;
            Destroy(other.gameObject);

        }
    }
}
