﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHSMarchenko
{    
    public interface IInteractable
    {
        float HoldDuration { get; }

        bool HoldInteract { get; }
        bool MultipleUse { get; }
        bool IsInteractable { get; }

        string TooltipMessage { get; }

        void OnInteract();
    }
}  
