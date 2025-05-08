using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile: MonoBehaviour
{
    public TileState state { get; private set; }
    public TileCell cell { get; private set; }
    public int number { get; private set; }

    private Image background;
    private TextMeshProUGUI text;

    private void Awake()
    {
        background = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetState(TileState state, int number)
    {
        this.state = state;
        this.number = number;

        background.color = state.backgroundColor;
        text.color = state.textColor;
        text.text = number.ToString();
    }

    public void Spawn(TileCell cell)
    {
        if (this.cell != null)
        {
            this.cell.tile = null;
        }

        this.cell = cell;
        this.cell.tile = this;

        transform.position = cell.transform.position;
    }

    public void MoveTo(TileCell cell)
    {
        if (this.cell != null)
        {
            this.cell.tile = null;
        }

        this.cell = cell;
        this.cell.tile = this;

        StartCoroutine(Animate(cell.transform.position));
    }

    private IEnumerator Animate(Vector3 to)
    {
        float el = 0f;
        float dur = 0.1f;

        Vector3 from = transform.position;

        while (el < dur)
        {
            transform.position = Vector3.Lerp(from, to, el / dur);
            el += Time.deltaTime;
            yield return null;
        }

        transform.position = to;
    }
}
