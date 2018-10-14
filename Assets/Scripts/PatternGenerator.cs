using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PatternGenerator : MonoBehaviour {

    public GameObject Circle;
    public GameObject Triangle;
    public GameObject Square;


    public LevelData[] levels;
    ColorWrapper[] colors;

    private void Awake()
    {

        colors = new ColorWrapper[3];
        colors[0] = new ColorWrapper
        {
            id = "red",
            color = new Color32(244, 67, 54, 255),
        };
        colors[1] = new ColorWrapper
        {
            id = "green",
            color = new Color32(76, 175, 80, 255),
        };
        colors[2] = new ColorWrapper
        {
            id = "blue",
            color = new Color32(33, 150, 243, 255),
        };

        int order = Manager.currentLevel.order + (Manager.currentLevel.tier * 3);
        LevelData data = levels[order];

        for (int i = 0; i < data.items.Length; i++) {
            Tile t = data.items[i];
            switch (t.tile) {
                case "c":
                    GameObject cItem = Instantiate(Circle, Vector2.zero, Quaternion.identity, transform) as GameObject;
                    cItem.GetComponent<RectTransform>().localPosition = new Vector2(-390 + ((i > 2 ? i + 1 : i) * 130), 0);
                    for (int j = 0; j < colors.Length; j++) {
                        ColorWrapper cw = colors[j];
                        if(cw.id == t.color) cItem.GetComponent<Image>().color = cw.color;
                    }

                    break;
                case "s":
                    GameObject sItem = Instantiate(Square, Vector2.zero, Quaternion.identity, transform) as GameObject;
                    sItem.GetComponent<RectTransform>().localPosition = new Vector2(-390 + ((i > 2 ? i + 1 : i) * 130), 0);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[j];
                        if (cw.id == t.color) sItem.transform.GetChild(0).GetComponent<Image>().color = cw.color;
                    }

                    break;
                case "t":
                    GameObject tItem = Instantiate(Triangle, Vector2.zero, Quaternion.identity, transform) as GameObject;
                    tItem.GetComponent<RectTransform>().localPosition = new Vector2(-390 + ((i > 2 ? i + 1 : i) * 130), 0);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[j];
                        if (cw.id == t.color) tItem.transform.GetChild(0).GetComponent<Image>().color = cw.color;
                    }

                    break;
            }
        }

        for (int i = 0; i < data.options.Length; i++)
        {
            Tile t = data.options[i];
            switch (t.tile)
            {
                case "c":
                    GameObject cOption = Instantiate(Circle, Vector2.zero, Quaternion.identity, transform) as GameObject;
                    cOption.GetComponent<RectTransform>().localPosition = new Vector2(-150 + (i * 150), -205);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[j];
                        if (cw.id == t.color) cOption.GetComponent<Image>().color = cw.color;
                    }


                    cOption.AddComponent<Button>();
                    Button c = cOption.GetComponent<Button>();
                    c.onClick.AddListener(() => Answer(data.answer, cOption));

                    break;
                case "s":
                    GameObject sOption = Instantiate(Square, Vector2.zero, Quaternion.identity, transform) as GameObject;
                    sOption.GetComponent<RectTransform>().localPosition = new Vector2(-150 + (i * 150), -205);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[j];
                        if (cw.id == t.color) sOption.transform.GetChild(0).GetComponent<Image>().color = cw.color;
                    }

                    sOption.AddComponent<Button>();
                    Button s = sOption.GetComponent<Button>();
                    s.onClick.AddListener(() => Answer(data.answer, sOption));

                    break;
                case "t":
                    GameObject tOption = Instantiate(Triangle, Vector2.zero, Quaternion.identity, transform) as GameObject;
                    tOption.GetComponent<RectTransform>().localPosition = new Vector2(-150 + (i * 150), -205);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[j];
                        if (cw.id == t.color) tOption.transform.GetChild(0).GetComponent<Image>().color = cw.color;
                    }

                    tOption.AddComponent<Button>();
                    Button tt = tOption.GetComponent<Button>();
                    tt.onClick.AddListener(() => Answer(data.answer, tOption));

                    break;
                default:
                    GameObject dOption = Instantiate(Circle, Vector2.zero, Quaternion.identity, transform) as GameObject;
                    dOption.GetComponent<RectTransform>().localPosition = new Vector2(-150 + (i * 150), -205);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ColorWrapper cw = colors[j];
                        if (cw.id == t.color) dOption.GetComponent<Image>().color = cw.color;
                    }

                    Button dd = dOption.AddComponent<Button>() as Button;
                    dd.onClick.AddListener(() => Answer(data.answer, dOption));

                    break;
            }
        }
    }

    void Answer(int answer, GameObject go) {
        bool isTrue = answer == go.transform.GetSiblingIndex() - 6;

        if (isTrue)
        {
            LevelController.instance.FinishLevel();
            SceneManager.LoadScene(5);
        }
        else {
            StarManager.instance.LooseAStar();
            go.SetActive(false);
        }
    }

    private void Start()
    {
        Countdown.instance.time = levels[Manager.currentLevel.order].time;
    }
}