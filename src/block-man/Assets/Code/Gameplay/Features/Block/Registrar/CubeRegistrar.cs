using System.Collections.Generic;
using Code.Infrastructure.View.Registrar;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Block.Registrar
{
    public class CubeRegistrar: EntityComponentRegistrar
    {
        public List<GameObject> Cube;
        
        public override void RegisterComponents()
        {
            Entity
                .AddCube(Cube);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasCube)
                Entity.RemoveCube();
        }
    }
}