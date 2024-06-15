﻿using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IncreaceCounter;

internal class IncreaceAnsweredCounter : IncreaceCounterBase
{
    public IncreaceAnsweredCounter(ITakeProfile takeProfile, IModifyProfile modifyProfile) : base(takeProfile, modifyProfile)
    {
    }
    protected override void Increace(Profile profile, int amount)
    {
        profile.AnsweredCount += (uint)amount;
    }
}
