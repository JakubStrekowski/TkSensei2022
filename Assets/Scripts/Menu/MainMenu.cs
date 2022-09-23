using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public string GameScene;

        public void StartGame()
        {
            SceneManager.LoadScene(GameScene);
        }
        
        public void Exit()
        {
            Application.Quit();
        }
    }
}