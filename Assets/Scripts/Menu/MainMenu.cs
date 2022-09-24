using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum MenuButtons
{
    StartBtn,
    OptionsBtn,
    CreditsBtn,
    ExitBtn,
};
namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public StoneSounds stoneSounds;
        public string GameScene;
        public RectTransform stone;

        public RectTransform[] buttons;

        public Vector3 originalPos;

        private void Start() 
        {
            originalPos = stone.position;
        }

        private void StartGame()
        {
            SceneManager.LoadScene(GameScene);
        }
        
        private void Exit()
        {
            Application.Quit();
        }
        private void CreditsAction()
        {
            Debug.Log("Credits opened");
        }
        private void OptionAction()
        {
            Debug.Log("Options opened");
        }

        public void StartClick()
        {
            StopCoroutine(nameof(PointStone));
            StartCoroutine(nameof(PointStone), 0);
        }
        public void OptionsClick()
        {
            StopCoroutine(nameof(PointStone));
            StartCoroutine(nameof(PointStone), 1);
        }
        public void CreditsClick()
        {
            StopCoroutine(nameof(PointStone));
            StartCoroutine(nameof(PointStone), 2);
        }
        public void ExitClick()
        {
            StopCoroutine(nameof(PointStone));
            StartCoroutine(nameof(PointStone), 3);
        }

        private IEnumerator PointStone(int buttonId)
        {
            float elapsedTime = 0f;
            Vector3 startPos = stone.position;

            Vector3 targetPos = buttons[buttonId].position;
            stoneSounds.PlayRandom();

            while (elapsedTime < 1f)
            {
                elapsedTime += Time.deltaTime;
                stone.position = Vector3.Lerp(startPos, targetPos, elapsedTime / 1f);
                yield return null;
            }

            stone.position = targetPos;

            switch (buttonId)
            {
                case 0:
                {
                    StartGame();
                    break;
                }
                case 1:
                {
                    OptionAction();
                    break;
                }
                case 2:
                {
                    CreditsAction();
                    break;
                }
                case 3:
                {
                    Exit();
                    break;
                }
            }
        }
    }
}