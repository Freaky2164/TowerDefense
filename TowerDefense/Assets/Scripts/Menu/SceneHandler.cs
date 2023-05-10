using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class SceneHandler : MonoBehaviour
    {
        public void loadMainMenuScene()
        {
            SceneManager.LoadScene(0);
            AudioHandler.I.Play(Sound.ButtonClick);
        }
        public void loadGameScene()
        {
            SceneManager.LoadScene(1);
            AudioHandler.I.Play(Sound.ButtonClick);
        }

        public void loadSettingsScene()
        {
            SceneManager.LoadScene(2);
            AudioHandler.I.Play(Sound.ButtonClick);
        }

        public void QuitGame()
        {
            Application.Quit();
            AudioHandler.I.Play(Sound.ButtonClick);
        }
    }
}