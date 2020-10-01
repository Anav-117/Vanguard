using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = .1f;
	public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time.time is time since the game began, vs. deltaTime, which is time since last frame
		float offset = Time.time * scrollSpeed;

		// texture offsets shift how the texture is drawn onto the 3D object, skewing its
		// UV coordinates; this results in a scrolling effect when applied on one axis
        rend.material.mainTextureOffset = new Vector2(0, offset);

		// shown out of curiosity, in case this texture had an associated bump map
		//rend.material.SetTextureOffset("_BumpMap", new Vector2(offset, 0));
    }
}
