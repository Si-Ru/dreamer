public class CustomerListMaker
{
    private string[] sexList = { "여", "남" };
    private string[] maleNameList = { "남병욱", "박하일", "박민관", "조정준", "채태륜", "윤남도", "윤성빈", "윤우태", "조경모", "순정훈", "최남익", "노영환", "도병모", "이수혁", "김세훈", "조범식", "민필범", "최남인", "유형철", "정장효", "이석주", "김운재", "성동주", "임장학", "권두협" };
    private string[] femaleNameList = { "송차연", "강지아", "하미정", "윤시원", "김수정", "이서린", "한도희", "최라윤", "박송이", "안서빈", "최채은", "조은혜", "김나옥", "김보경", "전채민", "조서영", "이규리", "임재선", "구혜빈", "정선미", "전미현", "최연주", "윤진경", "유희선", "조상옥" };
    private string[] maleProfileList = { "Character/Face/Character_Male1",
    "Character/Face/Character_Male2",
    "Character/Face/Character_Male4",
    "Character/Face/Character_Male6",
    "Character/Face/Character_Male7",
    "Character/Face/Character_Male10"};

    private string[] femaleProfileList = { "Character/Face/Character_Female1",
    "Character/Face/Character_Female2",
    "Character/Face/Character_Female3",
    "Character/Face/Character_Female4",
    "Character/Face/Character_Female7",
    "Character/Face/Character_Female8",
    "Character/Face/Character_Female9",
    "Character/Face/Character_Female10"};
    public CustomerListMaker()
    {
        player = Player.getPlayer();

        totalCustomerCnt = player.searchPow;
        enableCustomerCnt = player.customerCnt;
        customers = new Customer[totalCustomerCnt];
        if (GameState.DAY == 2)
        {
            customers[0] = new Customer("유안나", "여", "010-xxx-xxxx", 0, 1, 100, 3, "Character/Face/Character_Female1");
            customers[1] = new Customer("박현진", "여", "010-xxx-xxxx", 0, 2, 100, 3, "Character/Face/Character_Female6");
            customers[2] = new Customer("김진수", "남", "010-xxx-xxxx", 1, 1, 100, 3, "Character/Face/Character_Male1");
            customers[3] = new Customer("강성립", "남", "010-xxx-xxxx", 1, 2, 100, 3, "Character/Face/Character_Male4");
            customers[4] = new Customer("고영희", "여", "010-xxx-xxxx", 2, 3, 100, 3, "Character/Face/Character_Female7");
        }
        else
        {
            System.Random rand = new System.Random();
            for (int i = 0; i < totalCustomerCnt; i++)
            {
                customers[i] = new Customer();
                customers[i].sex = sexList[rand.Next(2)];
                if (customers[i].sex == sexList[0])
                {
                    customers[i].name = femaleNameList[rand.Next(25)];
                    customers[i].profileImage = femaleProfileList[rand.Next(8)];
                }
                else
                {
                    customers[i].name = maleNameList[rand.Next(25)];
                    customers[i].profileImage = maleProfileList[rand.Next(6)];
                }
                customers[i].characteristic = rand.Next(3);
                customers[i].difficultyLevel = rand.Next(4)+1;
                customers[i].health = 100 + rand.Next(10) * customers[i].difficultyLevel / 5;
                customers[i].inventory = rand.Next(2) + 1 + (customers[i].difficultyLevel-1)/2;
            }
        }
    }

    private Player player;

    public int totalCustomerCnt;
    public int enableCustomerCnt;
    public Customer[] customers;
}
