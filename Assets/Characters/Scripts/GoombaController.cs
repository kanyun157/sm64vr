﻿using UnityEngine;
using System.Collections;

public class GoombaController : EnemyController {
	public AudioClip jumpAudioClip;
	public AudioClip stepAudioClip;
	public float squashTimeExtension = 3;

	private bool startFollowPlayer;
	private bool squashed = false;

	protected override void Start() {
		startFollowPlayer = false;
		squashed = false;
		base.Start ();
	}

	protected void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == player.name) {
			base.Knockback(this.gameObject, player);
		} else if (col.gameObject.name == "LeftHandCollider" ||
		           col.gameObject.name == "RightHandCollider") {
			base.Knockback(player, this.gameObject, col.gameObject);
		} else if (col.gameObject.tag == "Grabbable") {
			base.Knockback(col.gameObject, this.gameObject);
		} else if (col.gameObject.name == "LeftFootCollider" ||
		           col.gameObject.name == "RightFootCollider") {
			if (!squashed) {
				StartCoroutine (Squash ());
			}
		}
	}

	protected override void FollowPlayer() {
		if (!startFollowPlayer) {
				StartCoroutine (Jumped ());
		} else {
			base.FollowPlayer ();
			if (!audio.isPlaying) {
				audio.clip = stepAudioClip;
				audio.Play();
			}
		}
	}

	protected IEnumerator Jumped () {
		animation.Play ("Jump");
		yield return new WaitForSeconds(animation ["Jump"].length);
		audio.clip = jumpAudioClip;
		audio.Play();
		animation.Play ("Walk");
		startFollowPlayer = true;
	}

	protected IEnumerator Squash () {
		squashed = true;
		ReboundPlayer (true);
		rigidbody.detectCollisions = false;
		movement = Movement.Freeze;
		animation.Play ("Squash");
		yield return new WaitForSeconds(animation ["Squash"].length + squashTimeExtension);
		dead = true;
		ToggleVisibility ();
		StartCoroutine(Death(0));
	}
}
