using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "Unity - Cycling An Object Through Rainbow Colors", Youtube Tutorial Video
public class RainbowColors : MonoBehaviour
{
    public Material mt;
    private Color32[] colors;
    private Color originalColor;
    private int activeCycleCount = 0; 
    private CollisionTrigger collision;
    private bool invincibilityState = false; // invincibility state

    // Start is called before the first frame update
    void Start()
    {
        mt = transform.GetComponent<MeshRenderer>().material;
        collision = GetComponent<CollisionTrigger>();
        originalColor = mt.color;
        colors = new Color32[7]
        {
            new Color32(255, 0, 0, 255), //red
            new Color32(255, 165, 0, 255), //orange
            new Color32(255, 255, 0, 255), //yellow
            new Color32(0, 255, 0, 255), //green
            new Color32(0, 0, 255, 255), //blue
            new Color32(75, 0, 130, 255), //indigo
            new Color32(238, 130, 238, 255), //violet
        };
    }

    public IEnumerator Cycle()
    {
        activeCycleCount++;
        invincibilityState = true;
        int i = 0;
        float timer = 0f;

        while(timer < 6.5f)
        {
            for(float interpolant = 0f; interpolant < 1f; interpolant+= 0.01f)
            {
                mt.color = Color.Lerp(colors[i%7], colors[(i+1)%7], interpolant);
                yield return null;
                timer += Time.deltaTime; // increment timer by time since last frame
            }
            i++;
        }

        Debug.Log("Rainbow effect stoppped after 6.5 seconds");
        mt.color = originalColor;

        activeCycleCount--;
        if (activeCycleCount == 0)
        {
            invincibilityState = false;
            collision.powerDownAudioSource.Play();
        }
    }

    public void StartRainbowCycle()
    {
        StartCoroutine(Cycle());
    }

    public bool isInvincible()
    {
        return invincibilityState;
    }
}