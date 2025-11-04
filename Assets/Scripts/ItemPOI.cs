using UnityEngine;

public class ItemPOI : MonoBehaviour
{
    [SerializeField] private GameObject itemPOI;
    [SerializeField] private float itemfatness = 2f;
    [SerializeField] private float BreathRate = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemPOI = itemPOI != null ? itemPOI : this.gameObject;
    }

    //Change item width to create a breathing effect
    private void BreathingEffect()
    {
        float scale = 1 + Mathf.Sin(Time.time * BreathRate) * (itemfatness - 1);
        itemPOI.transform.localScale = new Vector3(scale, scale, scale);
    }
    // Update is called once per frame
    void Update()
    {
        BreathingEffect();
    }
}
