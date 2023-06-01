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

        public void loadSettingsScene()
        {
            SceneManager.LoadScene(1);
            AudioHandler.I.Play(Sound.ButtonClick);
        }

        public void loadMapSelectionScene()
        {
            SceneManager.LoadScene(2);
            AudioHandler.I.Play(Sound.ButtonClick);
        }

        public void loadMap1Scene()
        {
            SceneManager.LoadScene(3);
            AudioHandler.I.Play(Sound.ButtonClick);
        }

        public void loadMap2Scene()
        {
            SceneManager.LoadScene(4);
            AudioHandler.I.Play(Sound.ButtonClick);
        }

        public void QuitGame()
        {
            Application.Quit();
            AudioHandler.I.Play(Sound.ButtonClick);
        }
    }
}