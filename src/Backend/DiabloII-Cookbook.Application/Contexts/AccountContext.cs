using Microsoft.Extensions.Logging;

namespace DiabloII_Cookbook.Application.Contexts
{
    public interface IAccountContext
    {
        string BattleTag { get; }
    }
    public interface IAccountContextMutator
    {
        void SetBattleTag(string battleTag);
    }

    public class AccountContext : IAccountContext, IAccountContextMutator
    {
        private readonly ILogger<AccountContext> _logger;

        private string _battleTag;
        public string BattleTag => _battleTag;

        public AccountContext(ILogger<AccountContext> logger)
        {
            _logger = logger;
        }

        void IAccountContextMutator.SetBattleTag(string battleTag)
        {
            _logger.LogDebug("Set BattleTag to {battleTag}", battleTag);
            _battleTag = battleTag;
        }
    }
}
