public class CustomerListMaker
{
    private string[] sexList = { "��", "��" };
    private string[] maleNameList = { "������", "������", "�ڹΰ�", "������", "ä�·�", "������", "������", "������", "�����", "������", "�ֳ���", "�뿵ȯ", "������", "�̼���", "�輼��", "������", "���ʹ�", "�ֳ���", "����ö", "����ȿ", "�̼���", "�����", "������", "������", "�ǵ���" };
    private string[] femaleNameList = { "������", "������", "�Ϲ���", "���ÿ�", "�����", "�̼���", "�ѵ���", "�ֶ���", "�ڼ���", "�ȼ���", "��ä��", "������", "�質��", "�躸��", "��ä��", "������", "�̱Ը�", "���缱", "������", "������", "������", "�ֿ���", "������", "����", "�����" };
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
            customers[0] = new Customer("���ȳ�", "��", "010-xxx-xxxx", 0, 1, 100, 3, "Character/Face/Character_Female1");
            customers[1] = new Customer("������", "��", "010-xxx-xxxx", 0, 2, 100, 3, "Character/Face/Character_Female6");
            customers[2] = new Customer("������", "��", "010-xxx-xxxx", 1, 1, 100, 3, "Character/Face/Character_Male1");
            customers[3] = new Customer("������", "��", "010-xxx-xxxx", 1, 2, 100, 3, "Character/Face/Character_Male4");
            customers[4] = new Customer("����", "��", "010-xxx-xxxx", 2, 3, 100, 3, "Character/Face/Character_Female7");
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
