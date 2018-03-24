// License: https://en.wikipedia.org/wiki/MIT_License
// Code created by Jeff Johnson & Digital Ruby, LLC - http://www.digitalruby.com
// Code is from the Free Parallax asset on the Unity asset store: http://u3d.as/bvv
// Code may be redistributed in source form, provided all the comments at the top here are kept intact

using UnityEngine;
using System.Collections;

public class FreeParallaxDemo : MonoBehaviour
{

    public FreeParallax parallax;
	[SerializeField]
	float speed = 4f;
	Rigidbody2D rb2D;

    // Use this for initialization
    void Start()
    {
		rb2D = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
		parallax.Speed = Mathf.Lerp (parallax.Speed, rb2D.velocity.x * speed, Time.deltaTime * speed);
    }
}
