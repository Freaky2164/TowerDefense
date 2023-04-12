using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class SceneHandler : MonoBehaviour
    {
        public void loadMainMenuScene()
        {
            SceneManager.LoadScene(0);
        }
        public void loadGameScene()
        {
            SceneManager.LoadScene(1);
        }

        public void loadSettingsScene()
        {
            SceneManager.LoadScene(2);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}