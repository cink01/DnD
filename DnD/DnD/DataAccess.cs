using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace DnD
{
    public class DataAccess
    {
        public List<Hero> GetHeroes(string n)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal(ConfigurationManager.ConnectionStrings["DnD.Properties.Settings.HeroesConnectionString"].ConnectionString)))
            {
                List<Hero> output = connection.Query<Hero>($"select * from hero where nazev_hero='{n}'").ToList();
                return output;
            }
        }

        public int GDice(string n)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DnD.Properties.Settings.HeroesConnectionString")))
            {
                var pass = (connection.Query<int>($"select dice_hero from hero where nazev_hero='{n}'")).Single();
                return Convert.ToInt32(pass);
            }
        }

        public string NamesHeroGet(int i)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DnD.Properties.Settings.HeroesConnectionString")))
            {
                var pass = (connection.Query<string>($"select nazev_hero from hero where id_hero='{i}'")).Single();
                return Convert.ToString(pass);
            }
        }

        public void GetStat(int i, out int a, out int b, out int c, out int d, out int e, out int f)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DnD.Properties.Settings.HeroesConnectionString")))
            {
                a = (connection.Query<int>($"select STR from Staty  where id={i}")).Single();
                b = (connection.Query<int>($"select DEX from Staty where id={i}")).Single();
                c = (connection.Query<int>($"select CON from Staty where id={i}")).Single();
                d = (connection.Query<int>($"select INT from Staty where id={i}")).Single();
                e = (connection.Query<int>($"select WIS from Staty where id={i}")).Single();
                f = (connection.Query<int>($"select CHA from Staty where id={i}")).Single();
            }
        }
        public void GetSkillProf(string x, int i, out int a)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DnD.Properties.Settings.HeroesConnectionString")))
            {
                a = (connection.Query<int>($"select {x} from Staty  where id={i}")).Single();
            }
        }

        public int GetIDstatu(string n)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DnD.Properties.Settings.HeroesConnectionString")))
            {
                try
                {
                    var pass = (connection.Query<int>($"select id from player where name_play='{n}'")).Single();
                    return Convert.ToInt32(pass);
                }
                catch
                {
                    return -1;
                }
            }
        }

        public int GetHPplay(string n)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DnD.Properties.Settings.HeroesConnectionString")))
            {
                try
                {
                    var pass = (connection.Query<int>($"select maxhp_play from player where name_play='{n}'")).Single();
                    return Convert.ToInt32(pass);
                }
                catch
                {
                    return -1;
                }
            }
        }

        public int Getlvlplay(string n)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DnD.Properties.Settings.HeroesConnectionString")))
            {
                try
                {
                    var pass = (connection.Query<int>($"select lvl_play from player where name_play='{n}'")).Single();
                    return Convert.ToInt32(pass);
                }
                catch
                {
                    return -1;
                }
            }
        }
    }
}