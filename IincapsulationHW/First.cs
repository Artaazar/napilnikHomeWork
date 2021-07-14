using System;

namespace IincapsulationHW
{
    //Если б я ещё умел работать с пулл реквестами 0_о
    public class Weapon
    {
        //Разница была по сути в сахаре. То есть никакой - зарабтался, забыл допилить решарпером xD
        //
        public int Damage { get; }
        public int Bullets { get; private set; }

        public Weapon(int damage, int bullets)
        {
            Damage = damage;
            Bullets = bullets;
        }
        // Если не хватает пуль - это ошибка.Из оружия без патронов стрелять нельзя. 
        //Можно. Дети стреляют даже из палок, вопрос в том что произойдёт дальше, как это действие должно обрабатываться.
        //Я читал когда-то про два варианта взаимодействия в рамках проекта: через получаемые результаты (в первоначальнм случае на спусковой крючок нажали, но ружжо щёлкнуло впустую)
        //Или через бросание эксепшенов и последующую их лювлю. Читал краем глаза и данный вопрос в лекции не поднимался.
        //
        public void Fire(Player player)
        {
            if (Bullets <= 0)
                throw new Exception("Боезапас пуст!");
            
            player.TakeDamage(Damage);
            Bullets -= 1;
        }
    }


    public class Player
    {
        public int Health { get; private set; }

        //У игрока расходится терминология, свойство Health а параметр конструктора почему-то hitPoints
        //Стогого говоря - да, но так - нет, это синнимы в игровом мире :), но для именования оно да, неверно было выбрано.
        //
        public Player(int health)
        {
            Health = health;
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

        //Зачем метод Heal? 
        //НУ как... Чтобы лечить. Метод нанесения урона игроку есть, значит должен быть и метод его лечения при подборе аптечки.
        //Автоматический оверинжиниринг, простите :)
        //
    }

    public class Bot
    {
        //Зачем у бота Weapon свойством?
        //Да, косяк. Оно ещё и публичным зачем-то было.
        //
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}
