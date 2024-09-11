using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class src_Models 
{
    #region - Player -
    [Serializable]
    public class PlayerSettingsModel 
    {
        [Header("View Settings")]
        public float view_X_sensitivity;
        public float view_Y_sensitivity;

        public bool view_X_inverted;
        public bool view_Y_inverted;
    }
    #endregion
}
