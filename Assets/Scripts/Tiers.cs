using UnityEngine;

public class Tiers : MonoBehaviour {
    public Sprite locked;
    public Sprite unlocked;
    public GameObject tier;
    public int numberOfTiers = 3;

    private void Awake()
    {
        for (int i = 0; i < numberOfTiers; i++) {
            GameObject _tier = Instantiate(tier, Vector2.zero, Quaternion.identity, transform);
            RectTransform rt = _tier.GetComponent<RectTransform>();
            rt.localPosition = new Vector2(-25, 182 - i * 220);
            _tier.name = "Tier " + i.ToString();
            Tier t = _tier.GetComponent<Tier>();
            t.tier = i;
            t.unlocked = unlocked;
            t.locked = locked;
        }
    }
}
