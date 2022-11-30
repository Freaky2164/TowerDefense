using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class CreateGame : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}