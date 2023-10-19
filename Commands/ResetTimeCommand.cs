using Mayuri.Services;

namespace Mayuri.Commands
{
    public class ResetTimeCommand : CommandBase
    {
        private readonly IImmersionTimeService _immersionTime;
        public ResetTimeCommand(IImmersionTimeService immersionTime)
        {
            _immersionTime = immersionTime;
        }
        public override void Execute(object? parameter)
        {
            _immersionTime.Reset();
        }
    }
}
