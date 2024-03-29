﻿using DesignPatternSamples.CreationalPatterns.Prototype.Entities;
using System;

namespace DesignPatternSamples.CreationalPatterns.Prototype.Interfaces
{
    public interface IPenalty
    {
        Guid Id { get; }
        string Description { get; }
        decimal Value { get; }
        Infringement Infringement { get; }
        DateTime CompetencyDate { get; }

        IPenalty DeepCopy();
        IPenalty ShallowCopy();
        void Initializer(DateTime competencyDate);
    }
}
