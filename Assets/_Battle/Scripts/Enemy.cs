using UnityEngine;

namespace BattleScripts
{
    internal interface IEnemy
    {
        void Update(PlayerData playerData);
    }

    internal class Enemy : IEnemy
    {
        private const float KMoney = 5f;
        private const float KPower = 1.5f;
        private const float MaxHealthPlayer = 20;
        private const float MaxWantedPlayer = 5;

        private readonly string _name;

        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;
        private int _wantedPlayer;


        public Enemy(string name) =>
            _name = name;


        public void Update(PlayerData playerData)
        {
            switch (playerData.DataType)
            {
                case DataType.Money:
                    _moneyPlayer = playerData.Value;
                    break;

                case DataType.Health:
                    _healthPlayer = playerData.Value;
                    break;

                case DataType.Power:
                    _powerPlayer = playerData.Value;
                    break;

                case DataType.Wanted:
                    _wantedPlayer = playerData.Value;
                    break;
            }

            Debug.Log($"Notified {_name} change to {playerData.DataType:F}");
        }

        public int CalcPower()
        {
            int kHealth = CalcKHealth();
            float moneyRatio = _moneyPlayer / KMoney;
            float powerRatio = _powerPlayer / KPower;
            float wantedRatio = _wantedPlayer;

            if (_wantedPlayer <= 2)
                return (int)((moneyRatio + kHealth + powerRatio) * 1);

            else
                return (int)(moneyRatio + kHealth + powerRatio);
        }

        private int CalcKHealth() =>
            _healthPlayer > MaxHealthPlayer ? 100 : 5;
        
    }
}

