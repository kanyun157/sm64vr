﻿/************************************************************************************

Filename    :   GameData.cs
Content     :   Store game data
Created     :   18 September 2014
Authors     :   Chris Julian Zaharia

************************************************************************************/

using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameData {

    public static GameData current;
    public bool optionControlsEnableRift;
    public bool optionControlsRiftPosTrackMove;         // Move via the Rift's positional tracker
    public bool optionControlsRiftPosTrackJump;         // Jump via the Rift's positional tracker

    public GameData () {
        this.optionControlsEnableRift = true;
        this.optionControlsRiftPosTrackMove = false;
        this.optionControlsRiftPosTrackJump = false;
    }
}
