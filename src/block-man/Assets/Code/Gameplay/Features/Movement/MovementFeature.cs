﻿using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature: Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<RotationSystem>());
            
            Add(systems.Create<TurnAlongDirectionSystem>());
            Add(systems.Create<ScaleGravitySystem>());
            Add(systems.Create<ChangeWorldPositionSystem>());
            Add(systems.Create<UpdateTransformPositionSystem>());
            Add(systems.Create<UpdateRigidbodyMovePositionSystem>());
            
        }
    }
}