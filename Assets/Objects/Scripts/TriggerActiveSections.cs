﻿/************************************************************************************

Filename    :   TriggerActiveSections.cs
Content     :   Handle render visibility and audio for sections of a scene based on triggers
Created     :   4 May 2014
Authors     :   Chris Julian Zaharia

************************************************************************************/

using UnityEngine;
using System.Collections;

public class TriggerActiveSections : MonoBehaviour {
	public GameObject[] loadSections;
	public GameObject[] unloadSections;
	public GameObject loadAudio;
	public GameObject unloadAudio;
	
	private AudioSource loadAudioSource;
	private AudioSource unloadAudioSource;

	void Awake() {
		if (loadAudio) {
			loadAudioSource = loadAudio.GetComponent<AudioSource>();
		}
		if (unloadAudio) {
			unloadAudioSource = unloadAudio.GetComponent<AudioSource>();
		}
	}

	// Load or unload areas in scene when player enters trigger
	protected void OnTriggerEnter () {
        TriggerSection ();
	}

    public virtual void TriggerSection () {
        if (loadSections.Length > 0) {
            TriggerSectionActiveness(loadSections, true);
        }
        
        if (unloadSections.Length > 0) {
            TriggerSectionActiveness(unloadSections, false);
        }
        
        if (unloadAudioSource) {
            unloadAudioSource.GetComponent<AudioSource>().Stop();
        }
        
        if (loadAudioSource) {
            loadAudio.GetComponent<AudioSource>().loop = true;
            loadAudio.GetComponent<AudioSource>().Play();
        }
    }

	private void TriggerSectionActiveness(GameObject[] sections, bool isActive) {
		foreach (GameObject section in sections) {
            section.SetActive (isActive);
		}		
	}
}
