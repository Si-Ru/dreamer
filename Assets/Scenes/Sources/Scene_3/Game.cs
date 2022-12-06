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
        maxHealth = player.health;
        maxTired = customer.health;
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
            int _k = rand.Next(3);
            int _l = rand.Next(3);
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
                calcDrawDamage(_p);
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

    private void calcWinDamage(Option _p)
    {

    }

    private void calcDrawDamage(Option _p)
    {

    }

    private void calcLoseDamage(Option _c)
    {

    }
}
