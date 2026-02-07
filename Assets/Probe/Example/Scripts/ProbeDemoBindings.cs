using Probe.Runtime.Core;
using UnityEngine;

namespace Probe.Example.Scripts
{
    public class ProbeDemoBindings : ProbeBinding
    {
        [SerializeField] private ProbeContext _context;
        [SerializeField] private Player player;
        [SerializeField] private Spawner spawner;

        private void Setup()
        {
            var registry = _context.Registry;

            registry.Floats.Register("Player.MoveSpeed",
                () => player.MoveSpeed,
                v => player.MoveSpeed = v
            );

            registry.Floats.Register("Spawner.Interval",
                () => spawner.SpawnInterval,
                v => spawner.SpawnInterval = v
            );
            
            registry.Floats.Register("Spawner.DestructionInterval",
                () => spawner.SelfDestructInterval,
                v => spawner.SelfDestructInterval = v
            );

            registry.Bools.Register("Spawner.Enabled",
                () => spawner.EnabledSpawning,
                v => spawner.EnabledSpawning = v
            );
        }

        public override void Bind(ProbeContext context)
        {
            _context = context;
            Setup();
        }
    }
}