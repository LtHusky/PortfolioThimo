using UnityEngine;

public class Shop : MonoBehaviour
{
    // VARIABLES
    private SpriteRenderer beamSpriteR;

    public GameObject beam;
    public Sprite newSprite;

    // FUNCTIONS
    void Start()
    {
        beamSpriteR = beam.GetComponent<SpriteRenderer>();
    }
    public void ChangeBeam()
    {
        beamSpriteR.sprite = newSprite;
    }
}
