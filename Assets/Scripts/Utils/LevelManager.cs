using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class LevelManager : MonoBehaviour
    {

        public void loadLevel(string level) {
            SceneManager.LoadScene(level);
        }

        public void quitGame()
        {
            Application.Quit();
        }
    }
}
