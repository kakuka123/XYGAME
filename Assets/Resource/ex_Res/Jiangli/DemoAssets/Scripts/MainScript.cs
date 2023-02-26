using UnityEngine;
using System.Collections;

// THIS SCRIPT ADDED TO THE PREFAS CAN BE USED TO CHECK THE ANIMATIONS ON THE DEMO SCENE //
// THE SPACE OPTION NEEDS TO BE CHANGED DEPENDING ON THE ANIMATION AVAILABLE ON THE PREFAB //

public class MainScript : MonoBehaviour {

	private Animator animator;

	void Start () {

		animator = GetComponent <Animator> ();



	}

	void Update () {


		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			animator.Play("anim_idle");

		}
		
		if (Input.GetKeyDown("space")){

			animator.Play("anim_open");
			//animator.Play("anim_rotation");
			//animator.Play("anim_play");
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {

			animator.Play("anim_fall");
		}

	}
}
