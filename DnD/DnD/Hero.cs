namespace DnD
{
    public class Hero
    {
        public int id_hero { get; set; }
        public string nazev_hero { get; set; }
        public int dice_hero { get; set; }

        public string FullInfo
        {
            get
            {
                return nazev_hero + " " + dice_hero.ToString();
            }
        }

        /*public Hero(int a,string b,int c) {
            id_hero = a;
            nazev_hero = b;
            dice_hero = c;
        }*/
    }
}