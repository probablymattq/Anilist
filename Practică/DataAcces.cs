using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Practică
{
    public class DataAcces
    {

        public String GetLoginData(string email, string pass)
        {
            Login login = new Login();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                var output = connection.Query<LoginDB>($"select * from LOGINDATA where email = '{email}'");
                if (output.Any())
                {
                    if (output.First().pass == pass)
                    {
                        return output.First().username;
                    }
                    else
                    {
                        return "invalid";
                    }
                }
                else
                {
                    return "invalid";
                }
            }
        }

        public void InsertData(string username, string email, string pass)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                List<LoginDB> data = new List<LoginDB>();

                data.Add(new LoginDB { username = username, email = email, pass = pass });

                connection.Query<LoginDB>($"insert into LOGINDATA(username, email, pass) VALUES ('{username}', '{email}', '{pass}')");
            }
        }

        public void SetCurrentSession(string email, string username)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                connection.Query<LoginDB>($"if exists(select * from CURRENTSESSION)" +
                    $"update CURRENTSESSION set username = '{username}', email = '{email}'" +
                    $"else insert into CURRENTSESSION(email, username) values ('{email}', '{username}')");
            }
        }

        public List<CurrentSession> GetCurrentSession()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                var output = connection.Query<CurrentSession>($"select * from CURRENTSESSION").ToList();
                return output;
            }
        }

        public List<LoginDB> CheckMail(string email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                var output = connection.Query<LoginDB>($"select username from LOGINDATA where email = '{email}'").ToList();
                return output;

            }
        }

        public List<Anime> GetAnime()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                var output = connection.Query<Anime>($"select * from ANIMEDATA").ToList();
                return output;
            }
        }

        public List<AnimePersonal> GetAnimePersonal(int idanime, string email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                var output = connection.Query<AnimePersonal>($"select * from ANIMEDATAPERSONAL where idanime = '{idanime}' and email_user = '{email}'").ToList();
                return output;
            }
        }

        public List<AnimePersonal> GetAnimePersonal2(string email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                var output = connection.Query<AnimePersonal>($"select * from ANIMEDATAPERSONAL where email_user = '{email}'").ToList();
                return output;
            }
        }

        public void InsertInPersonal(int idanime, string emailuser, string numeanime, int nrepisoade, string status, string dataaparitie, int idstudio, int idgen, int idsezon, string animeimage)
         {
             using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
             {
                 connection.Query<AnimePersonal>($"insert into ANIMEDATAPERSONAL (idanime, email_user, numeanime, nrepisoade, status, dataaparitie, idstudio, idgen, idsezon, animeimage) " +
                     $"VALUES ('{idanime}', '{emailuser}', '{numeanime}', '{nrepisoade}', '{status}', '{dataaparitie}', '{idstudio}', '{idgen}', '{idsezon}', '{animeimage}')");
             }
         }

        public void RemoveFromPersonal(int idanime)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                connection.Query<AnimePersonal>($"delete from ANIMEDATAPERSONAL where idanime = '{idanime}'");
            }
        }

        public class studio
        {
            public string numestudio;
        };

        public class sezon
        {
            public string numesezon;
        };

        public class gen
        {
            public string numegen;
        }

        public string GetStudio(int idstudio)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                var studio = connection.Query<studio>($"select numestudio from STUDIO where idstudio = '{idstudio}'").ToList();
                return studio.First().numestudio;
            }
        }

        public string GetSezon(int idsezon)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                var sezon = connection.Query<sezon>($"select numesezon from SEZON where idsezon = '{idsezon}'").ToList();
                return sezon.First().numesezon;
            }
        }

        public string GetGen(int idgen)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AnilistDB")))
            {
                var gen = connection.Query<gen>($"select numegen from GEN where idgen = '{idgen}'").ToList();
                return gen.First().numegen;
            }
        }
    }
}