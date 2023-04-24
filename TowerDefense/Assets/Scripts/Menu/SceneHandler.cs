using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class SceneHandler : MonoBehaviour
    {
        public void loadMainMenuScene()
        {
            SceneManager.LoadScene(0);
            AudioManager.instance.Play("ButtonClick");
        }
        public void loadGameScene()
        {
            SceneManager.LoadScene(1);
            AudioManager.instance.Play("ButtonClick");
        }

        public void loadSettingsScene()
        {
            SceneManager.LoadScene(2);
            AudioManager.instance.Play("ButtonClick");
        }

        public void QuitGame()
        {
            Application.Quit();
            AudioManager.instance.Play("ButtonClick");
        }
    }
}