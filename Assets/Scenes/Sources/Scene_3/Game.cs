using System.Collections.Generic;
using System;

public class Option
{
    public Option(int _k, int _l) => (kind, level) = (_k, _l);
    public int kind; // 종류
    public int level;// 레벨
}

public class Game
{
    private Player player;

    public Customer customer;
    public int currentTheme;
    public int currentHealth;
    public int currentTired;
    public int maxHealth;
    public int maxTired;

    public Option[] playerInventory;
    public Option[] customerInventory;

    public Game(Customer _customer)
    {
        customer = _customer;
        player = Player.getPlayer();
        maxHealth = customer.health;
        maxTired = player.health;
        currentHealth = 0;
        currentTired = 0;

        playerInventory = new Option[player.inventory];
        Random rand = new Random();
        for(int i=0;i<player.inventory;i++)
        {
            int _k = rand.Next(3);
            int _l = rand.Next(3);
            playerInventory[i] = new Option(_k, _l);
        }

        customerInventory = new Option[customer.inventory];
        for (int i = 0; i < customer.inventory; i++)
        {
            int _k = rand.Next(1);
            int _l = rand.Next(1);
            customerInventory[i] = new Option(_k, _l);
        }

        currentTheme = rand.Next(3);

        // UI Initialize
    }

    public void selectInventory(int _pi)
    {
        Option _p = playerInventory[_pi];
        Option _c = customerInventory[0];
        int j, _ci = 0;
        for (j = 1; j < customer.inventory; j++)
        {
            if(_c.kind != currentTheme && customerInventory[j].kind == currentTheme)
            {
                _c = customerInventory[j];
                _ci = j;
            }
            else if(_c.level > customerInventory[j].level)
            {
                _c = customerInventory[j];
                _ci = j;
            }
        }

        if (_p.kind == currentTheme && _c.kind == currentTheme
         || _p.kind != currentTheme && _c.kind != currentTheme)
        {
            if (_p.level < _c.level) // customer win
            {
                calcLoseDamage(_c);
            }
            else if (_p.level == _c.level) // draw
            {
                calcDrawDamage(_p, _c);
            }
            else // player win
            {
                calcWinDamage(_p);
            }
        }
        else
        {
            if (_p.kind == currentTheme) // player win
            {
                calcWinDamage(_p);
            }
            else
            {
                calcLoseDamage(_c);
            }
        }

        Random rand = new Random();
        int _k = rand.Next(3);
        int _l = rand.Next(3);
        playerInventory[_pi] = new Option(_k, _l);
        _k = rand.Next(3);
        _l = rand.Next(3);
        customerInventory[_ci] = new Option(_k, _l);

        //update UI
    }

    public void selectInventory(int _pi, int _ci)
    {
        Option _p = playerInventory[_pi];
        Option _c = customerInventory[_ci];

        if (_p.kind == currentTheme && _c.kind == currentTheme
         || _p.kind != currentTheme && _c.kind != currentTheme)
        {
            if (_p.level < _c.level) // customer win
            {
                calcLoseDamage(_c);
            }
            else if (_p.level == _c.level) // draw
            {
                calcDrawDamage(_p, _c);
            }
            else // player win
            {
                calcWinDamage(_p);
            }
        }
        else
        {
            if (_p.kind == currentTheme) // player win
            {
                calcWinDamage(_p);
            }
            else
            {
                calcLoseDamage(_c);
            }
        }

        Random rand = new Random();

        int _tmp = rand.Next(4);
        if (_tmp == 0)
        {
            currentTheme = (currentTheme + rand.Next(2) + 1) % 3;
        }

        
        int _k = currentTheme;//rand.Next(3);
        int _l = rand.Next(3);
        playerInventory[_pi] = new Option(_k, _l);
        _k = rand.Next(3);
        _l = rand.Next(3);
        customerInventory[_ci] = new Option(_k, _l);
        //update UI
    }

    int defaultTired = 5;

    private void calcWinDamage(Option _p)
    {
        currentTired += defaultTired;
        currentHealth += (int)(15.0f * (1.0f + (float)_p.level / 5.0f) * (1.0f + (_p.kind == customer.characteristic ? 1.0f : 0.0f) * 0.2f));

        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentTired > maxTired) currentTired = maxTired;
    }

    private void calcDrawDamage(Option _p, Option _c)
    {
        currentTired += defaultTired + 10;
        currentHealth += (int)(5.0f * (1.0f+(float)(_p.level-_c.level)/5.0f) * (1.0f + (_p.kind == customer.characteristic ? 1.0f : 0.0f) * 0.2f));

        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentTired > maxTired) currentTired = maxTired;
    }

    private void calcLoseDamage(Option _c)
    {
        currentTired += (int)((float)defaultTired + 15.0f * (1.0f + (float)_c.level / 5.0f));

        if (currentTired > maxTired) currentTired = maxTired;
    }
}
