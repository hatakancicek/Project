using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternGenerator : MonoBehaviour {

    public GameObject Circle;
    public GameObject Triangle;
    public GameObject Square;

    public LevelData[] levels;
    public ColorWrapper[] colors;

    private void Awake()
    {
        int order = Manager.currentLevel.order;
        LevelData data = levels[order];
        GameObject item;
        for (int i = 0; i < data.items.Length; i++) {
            Tile t = data.items[i];
            switch (t.tile) {
                case "c":
                    item = Instantiate(Circle, Vector2.zero, Quaternion.identity, transform);
                    item.GetComponent<RectTransform>().localPosition = new Vector2(-390 + (i * 130), 0);
                    for (int j = 0; j < colors.Length; j++) {
                        ColorWrapper cw = colors[i];
                        if(cw.id == t.color) item.GetComponent<SpriteRenderer>().color = cw.color;
                    }

                    break;
                case "s":
                    item = Instantiate(Square, Vector2.zero, Quaternion.identity, transform);
                    item.GetComponent<RectTransform>().localPosition = new Vector2(-390 + (i * 130), 0);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[i];
                        if (cw.id == t.color) item.transform.GetChild(0).GetComponent<SpriteRenderer>().color = cw.color;
                    }

                    break;
                case "t":
                    item = Instantiate(Triangle, Vector2.zero, Quaternion.identity, transform);
                    item.GetComponent<RectTransform>().localPosition = new Vector2(-390 + (i * 130), 0);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[i];
                        if (cw.id == t.color) item.transform.GetChild(0).GetComponent<SpriteRenderer>().color = cw.color;
                    }

                    break;
            }
        }

        for (int i = 0; i < data.options.Length; i++)
        {
            Tile t = data.items[i];
            switch (t.tile)
            {
                case "c":
                    item = Instantiate(Circle, Vector2.zero, Quaternion.identity, transform);
                    item.GetComponent<RectTransform>().localPosition = new Vector2(-150 + (i * 150), -205);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[i];
                        if (cw.id == t.color) item.GetComponent<SpriteRenderer>().color = cw.color;
                    }

                    break;
                case "s":
                    item = Instantiate(Square, Vector2.zero, Quaternion.identity, transform);
                    item.GetComponent<RectTransform>().localPosition = new Vector2(-150 + (i * 150), -205);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[i];
                        if (cw.id == t.color) item.transform.GetChild(0).GetComponent<SpriteRenderer>().color = cw.color;
                    }

                    break;
                case "t":
                    item = Instantiate(Triangle, Vector2.zero, Quaternion.identity, transform);
                    item.GetComponent<RectTransform>().localPosition = new Vector2(-150 + (i * 150), -205);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[i];
                        if (cw.id == t.color) item.transform.GetChild(0).GetComponent<SpriteRenderer>().color = cw.color;
                    }

                    break;
                default:
                    item = Instantiate(Circle, Vector2.zero, Quaternion.identity, transform);
                    item.GetComponent<RectTransform>().localPosition = new Vector2(-150 + (i * 150), -205);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[i];
                        if (cw.id == t.color) item.GetComponent<SpriteRenderer>().color = cw.color;
                    }

                    break;
            }

            Button b = item.AddComponent<Button>() as Button;
            b.onClick.AddListener(() => Answer(data.answer == i, item));
        }
    }

    void Answer(bool isTrue, GameObject go) {
        if (isTrue) LevelController.instance.FinishLevel();
        else {
            StarManager.instance.LooseAStar();
            Destroy(go);
        }
    }
}