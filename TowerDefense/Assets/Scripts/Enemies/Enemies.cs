using UnityEngine;

namespace Enemies
{
    public class Enemies : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemy1Prf;

        public GameObject Enemy1Prf => enemy1Prf;
        
    }
}