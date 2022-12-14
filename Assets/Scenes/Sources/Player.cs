public class Player
{
    private static Player player = null;
    public static Player getPlayer()
    {
        if(player == null)
        {
            player = new Player();
            player.name = "test";
            player.ethosPow = 10;
            player.logosPow = 10;
            player.pathosPow = 10;
            player.health = 100;
            player.inventory = 3;
            player.customerCnt = 2;
            player.searchPow = 5;
        }

        return player;
    }

    public string name;
    public int ethosPow;
    public int logosPow;
    public int pathosPow;
    public int health;
    public int inventory;
    public int customerCnt;
    public int searchPow;

    public int statPoint;
}