public class Customer
{
    public Customer(string _name, string _sex, string _phone, int _char, int _diff, int _health, int _inventory, string _profileImage)
        => (name, sex, phone, characteristic, difficultyLevel, health, inventory, profileImage) = (_name, _sex, _phone, _char, _diff, _health, _inventory, _profileImage);

    public Customer() {
    }

    public string name;
    public string sex;
    public string phone;
    public string profileImage;
    public int characteristic;
    public int difficultyLevel;
    public int health;
    public int inventory;
}
