namespace IincapsulationHW
{
    public class Weapon
    {
        public int Damage { get; }

        private int _bullets;
        public int Bullets => _bullets;

        public Weapon(int damage, int bullets)
        {
            Damage = damage;
            _bullets = bullets;
        }

        public void Fire(Player player)
        {
            if (Bullets > 0)
            {
                player.TakeDamage(Damage);
                _bullets -= 1;
            }
        }
    }
    

    public class Player
    {
        public int Health { get; private set; }

        public Player(int hitPoints)
        {
            Health = hitPoints;
        }

        public Player() : this(100)
        {
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }
        public void Heal(int healedPoints)
        {
            if (Health <= 0)
                return;

            Health += healedPoints;
        }
    }

    public class Bot
    {
        public Weapon Weapon { get; }

        public Bot(Weapon weapon)
        {
            Weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}
