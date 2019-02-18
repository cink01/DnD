using System;
using System.Linq;

namespace DnD
{
    public class statisiky
    {
        private int[] poleStaty;

        public statisiky()
        {
            poleStaty = new int[6];
            for (int i = 0; i <= 5; i++)
                poleStaty[i] = 0;
        }

        public void RNGstaty()
        {
            int a, b, c, d, i;
            Random r = new Random();
            i = 0;
            while (i != 6)
            {
                a = 0;
                b = 0;
                c = 0;
                d = 0;
                a = r.Next(1, 7);
                b = r.Next(1, 7);
                c = r.Next(1, 7);
                d = r.Next(1, 7);
                int min = Math.Min(Math.Min(Math.Min(a, b), c), d);
                poleStaty[i] = a + b + c + d - min;
                i++;
            }
        }

        public int VratStat(int misto)
        {
            return poleStaty[misto];
        }
    }

    public class Modifier
    {
        public int Modif(int x)
        {
            return (x / 2) - 5;
        }
    }

    public class Pocitani
    {
        public static int Min(int x, int y)
        {
            return Math.Min(x, y);
        }

        public static int Min(int x, int y, int z)
        {
            return Math.Min(x, Math.Min(y, z));
        }

        public static int Min(int w, int x, int y, int z)
        {
            return Math.Min(w, Math.Min(x, Math.Min(y, z)));
        }

        public static int Min(params int[] values)
        {
            return Enumerable.Min(values);
        }

        public static Int32 MyRandom(Int32 iMin, Int32 iMax)
        {
            Random rnd = new Random();
            return rnd.Next(iMin, iMax);
        }

        public static decimal Roll20() => MyRandom(1, 21);

        /*  private class Char_Class
          {
              private string class_name;
              private int class_dice;
              public string Class_name { get; set; }
              public string Class_dice { get; set; }
          }*/
    }
}

/*
class stats
{
    int strenght_Base;
    int dexterity_Base;
    int constitution_Base;
    int inteligence_Base;
    int wisdom_Base;
    int charisma_Base;
    int pocitadlo;
   public stats()
    {
        RandomStat a = new RandomStat();
        strenght_Base = a.CountStat();
        RandomStat aa = new RandomStat();
        dexterity_Base = aa.CountStat();
        RandomStat ab = new RandomStat();
        constitution_Base = ab.CountStat();
        RandomStat ac = new RandomStat();
        inteligence_Base = ac.CountStat();
        RandomStat ad = new RandomStat();
        wisdom_Base = ad.CountStat();
        RandomStat ae = new RandomStat();
        charisma_Base = ae.CountStat();
    }
    public int getStrenght_Base()
    {
        //      RandomStat a = new RandomStat();
        //      strenght_Base = a.CountStat();
        return strenght_Base;
    }
    public int getDexterity_Base()
    {
        //RandomStat aa = new RandomStat();
        //dexterity_Base = aa.CountStat();
        return dexterity_Base;
    }
    public int getConstitution_Base()
    {
        //RandomStat ab = new RandomStat();
        // constitution_Base = ab.CountStat();
        return constitution_Base;
    }
    public int getInteligence_Base()
    {
        // RandomStat ac = new RandomStat();
        //  inteligence_Base = ac.CountStat();
        return inteligence_Base;
    }
    public int getSWisdom_Base()
    {
        //  RandomStat ad = new RandomStat();
        // wisdom_Base = ad.CountStat();

        return wisdom_Base;
    }
    public int getCharisma_Base()
    {
        // RandomStat ae = new RandomStat();
        //  charisma_Base = ae.CountStat();
        return charisma_Base;
    }
}
*/

/*
public class RandomStat
{
    public int CountStat()
    {
        Pocitani p = new Pocitani();
        int a, b, c, d, min;
        a = 0;
        b = 0;
        c = 0;
        d = 0;
        min = 0;
        a = p.MyRandom(1,7);
        b = Pocitani.RNG();
        c = Pocitani.RNG();
        d = Pocitani.RNG();
        min = Math.Min(Math.Min(Math.Min(a, b), c), d);
        return a + b + c + d-min;
    }
}
*/