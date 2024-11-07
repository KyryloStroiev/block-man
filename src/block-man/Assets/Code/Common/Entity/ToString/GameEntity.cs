using System;
using System.Linq;
using System.Text;
using Code.Common.Entity.ToString;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Block;
using Entitas;
using UnityEngine;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
    private EntityPrinter _printer;

    public override string ToString()
    {
        if (_printer == null)
            _printer = new EntityPrinter(this);

        _printer.InvalidateCache();

        return _printer.BuildToString();
    }

    public string EntityName(IComponent[] components)
    {
        try
        {
            if (components.Length == 1)
                return components[0].GetType().Name;

            foreach (IComponent component in components)
            {
                switch (component.GetType().Name)
                {
                    case nameof(HeroComponents.Hero):
                        return PrintHero();

                    case nameof(Block):
                        return PrintBlock();
                    
                    case nameof(SpawnPoint):
                        return PrintSpawnPoint();
                }
            }
        }
        catch (Exception exception)
        {
            Debug.LogError(exception.Message);
        }

        return components.First().GetType().Name;
    }

    private string PrintSpawnPoint()
    {
        return new StringBuilder($"SpawnPoint ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
    }

    private string PrintHero()
    {
        return new StringBuilder($"Hero ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
    }
  
    private string PrintBlock() =>
        new StringBuilder($"Block ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
  
    public string BaseToString() => base.ToString();
}