using System.Collections;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public CanvasGroup gameOver;
    public TileBoard board;

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        gameOver.alpha = 0f;
        gameOver.interactable = false;

        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;

        StartCoroutine(Fade(gameOver, 1f, 1));
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float el = 0f;
        float dur = 0.5f;
        float from = canvasGroup.alpha;

        while (el < dur)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, el / dur);
            el += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
