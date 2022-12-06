

public class CustomerListMaker
{
    public CustomerListMaker()
    {
        player = Player.getPlayer();

        totalCustomerCnt = player.searchPow;
        enableCustomerCnt = player.customerCnt;

        customers = new Customer[totalCustomerCnt];
        if (GameState.DAY == 2)
        {
            customers[0] = new Customer("유안나", "여", "010-xxx-xxxx", 0, 1, 100, 3, "Character_Female1");
            customers[1] = new Customer("박현진", "여", "010-xxx-xxxx", 0, 2, 100, 3, "Character_Female6");
            customers[2] = new Customer("김진수", "남", "010-xxx-xxxx", 1, 1, 100, 3, "Character_Male1");
            customers[3] = new Customer("강성립", "남", "010-xxx-xxxx", 1, 2, 100, 3, "Character_Male4");
            customers[4] = new Customer("고영희", "여", "010-xxx-xxxx", 2, 3, 100, 3, "Character_Female7");
        }
        else
        {
            for (int i = 0; i < totalCustomerCnt; i++)
            {
                customers[i] = new Customer();
                //generate random customer
            }
        }
    }

    private Player player;

    private static int FEMALE_IMAGE_CNT = 10;
    private static int MALE_IMAGE_CNT = 10;

    public int totalCustomerCnt;
    public int enableCustomerCnt;
    public Customer[] customers;
}
