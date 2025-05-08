using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileGrid: MonoBehaviour
{
    public TileRow[] rows { get; private set; }
    public TileCell[] cells { get; private set; }
    public int size => cells.Length;
    public int height => rows.Length;
    public int width => size / height;

    private void Awake()
    {
        rows = GetComponentsInChildren<TileRow>();
        cells = GetComponentsInChildren<TileCell>();
    }

    private void Start()
    {
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < rows[i].cells.Length; j++)
            {
                rows[i].cells[j].coordinates = new Vector2Int(j, i);
            }
        }
    }

    public TileCell GetRandomEmptyCell()
    {
        int i = Random.Range(0, cells.Length);
        int s = i;

        while (cells[i].occupied)
        {
            i++;

            if (i >= cells.Length)
            {
                i = 0;
            }

            if (i == s)
            {
                return null;
            }
        }

        return cells[i];
    }
}
