using System;

public class Customer
{
    public Customer(string _name, string _sex, string _phone, int _char, int _diff, int _health, int _inventory, string _profileImage)
        => (name, sex, phone, characteristic, difficultyLevel, health, inventory, profileImage) = (_name, _sex, _phone, _char, _diff, _health, _inventory, _profileImage);

    public Customer(string _name, string _sex, string _phone, string _char, string _diff, string _health, string _inventory, string _profileImage)
        => (name, sex, phone, characteristic, difficultyLevel, health, inventory, profileImage) = (_name, _sex, _phone, Int32.Parse(_char), Int32.Parse(_diff), Int32.Parse(_health), Int32.Parse(_inventory), _profileImage);

    public Customer(string customerString)
    {
        string[] st = customerString.Split(',');
        (name, sex, phone, characteristic, difficultyLevel, health, inventory, profileImage) = (st[0], st[1], st[2], Int32.Parse(st[3]), Int32.Parse(st[4]), Int32.Parse(st[5]), Int32.Parse(st[6]), st[7]);
        //Customer(st[0],st[1],st[2],st[3],st[4],st[5],st[6],st[7]);
    }

    public Customer() {
        phone = "010-xxx-xxxx";
    }

    public string name;
    public string sex;
    public string phone;
    public int characteristic;
    public int difficultyLevel;
    public int health;
    public int inventory;
    public string profileImage;

    public string toString()
    {
        return string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",name,sex,phone,characteristic,difficultyLevel,health,inventory,profileImage);
    }
}
