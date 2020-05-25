using Microsoft.Data.Sqlite;
using System;

namespace DogeQuiz
{
    public class SQLite
    {


        public static SqliteConnection CreateConnection()
        {
            SqliteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SqliteConnection("Data Source= BazaPsow.db;");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        public static void CreateTable(SqliteConnection conn)
        {

            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();


            string CreateAnswers = "CREATE TABLE IF NOT EXISTS answers (id_answers INTEGER NOT NULL UNIQUE, answer TEXT NOT NULL UNIQUE,PRIMARY KEY(id_answers))";
            string CreateQuestions = "CREATE TABLE IF NOT EXISTS questions (id_question INTEGER NOT NULL UNIQUE, question TEXT NOT NULL UNIQUE, correct_answer INTEGER NOT NULL,PRIMARY KEY(id_question), FOREIGN KEY(correct_answer) REFERENCES answers(id_answers))";
            string CreateConnections = "CREATE TABLE IF NOT EXISTS connections (id_connection	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, id_question INTEGER NOT NULL, id_answer INTEGER NOT NULL, FOREIGN KEY(id_question) REFERENCES questions(id_question), FOREIGN KEY(id_answer) REFERENCES answers(id_answers))";

            sqlite_cmd.CommandText = CreateAnswers;
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = CreateQuestions;
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = CreateConnections;
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void InsertData(SqliteConnection conn)
        {
            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (1,'6-8 miesiącach'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (2,'12-18 miesiącach'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (3,'20-24 miesiącach'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (4,'tak samo jak człowiek'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (5,'widzi w odcieniach szarości'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (6,'rozróżnia mniej kolorów od człowieka'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (7,'na łapach'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (8,'na grzbiecie'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (9,'na nosie'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (10,'czekolady i awkoado'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (11,'sera żółtego i bananów'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (12,'buraków i kurzych jaj na twardo'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (13,'na zimę i lato'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (14,'na wiosnę i jesień'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (15,'każdej pory roku'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (16,'dyszenie'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (17,'ziewanie'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (18,'drapanie'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (19,'16'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (20,'20'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (21,'18'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (22,'bichony/maltańczyki'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (23,'yorki/mopsy'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (24,'owczarki niemieckie/maltańczyki'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (25,'dogi niemieckie/wilczarze irlandzkie'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (26,'chihuahua/shih tzu'); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO answers (id_answers,answer) VALUES (27,'wilczarze irlandzkie/jamniki'); ";
            sqlite_cmd.ExecuteNonQuery();


            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (1,'Kiedy pies jest dorosły? Zazwyczaj po około:',2); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (2,'Jak pies widzi kolory?',6); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (3,'Gdzie pies się poci?',7); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (4,'Czego pies nie może jeść?',10); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (5,'Kiedy pies linieje?',14); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (6,'W jaki sposób pies chłodzi swój organizm? Poprzez:',16); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (7,'Ile pies ma palców? To zazwyczaj?',21); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (8,'Które psy mają włosy? Są to np:',24); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (9,'Które psy żyją najdłużej? Między innymi:',27); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO questions (id_question,question,correct_answer) VALUES (10,'A które psy żyją najkrócej?',26); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (1,1,1); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (2,2,1); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (3,3,1); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (4,4,2); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (5,5,2); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (6,6,2); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (7,7,3); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (8,8,3); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (9,9,3); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (10,10,4); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (11,11,4); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (12,12,4); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (13,13,5); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (14,14,5); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (15,15,5); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (16,16,6); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (17,17,6); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (18,18,6); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (19,19,7); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (20,20,7); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (21,21,7); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (22,22,8); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (23,23,8); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (24,24,8); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (25,25,9); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (26,26,9); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (27,27,9); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (28,25,10); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (29,26,10); ";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO connections (id_connection,id_answer,id_question) VALUES (30,27,10); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        //public static string ReadQuestion(SqliteConnection conn, int i)
        //{
        //    SqliteDataReader sqlite_datareader;
        //    SqliteCommand sqlite_cmd;
        //    sqlite_cmd = conn.CreateCommand();
        //    sqlite_cmd.CommandText = "select question from questions where id_question =" + i + ";";
        //    string question = "";
        //    sqlite_datareader = sqlite_cmd.ExecuteReader();
        //    while (sqlite_datareader.Read())
        //    {
        //        question = sqlite_datareader.GetString(0);
        //    }
        //    return question;
        //}

        public static SqliteDataReader ReadAnswers(SqliteConnection conn, int i)
        {
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "select answer, correct_answer from answers inner join connections on answers.id_answers = connections.id_answer inner join questions on connections.id_question=questions.id_question where connections.id_question =" + i + ";";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            return sqlite_datareader;
        }

        //public static string ReadCorrectAnswers(SqliteConnection conn, int i)
        //{
        //    SqliteDataReader sqlite_datareader;
        //    SqliteCommand sqlite_cmd;
        //    sqlite_cmd = conn.CreateCommand();
        //    sqlite_cmd.CommandText = "select answer from questions inner join answers on questions.correct_answer = answers.id_answers where id_question = " + i + ";";
        //    string correct_answer = "";
        //    sqlite_datareader = sqlite_cmd.ExecuteReader();

        //    while (sqlite_datareader.Read())
        //    {
        //        correct_answer = sqlite_datareader.GetString(0);
        //    }
        //    return correct_answer;
        //}

        public static bool tableExists(string tableName, SqliteConnection conn)
        {
            bool exists;
            conn.Open();

            try
            {
                var cmd = new SqliteCommand(
                  "select case when exists((select * from information_schema.tables where table_name = '" + tableName + "')) then 1 else 0 end", conn);

                exists = (int)cmd.ExecuteScalar() == 1;
            }
            catch
            {
                try
                {
                    exists = true;
                    var cmdOthers = new SqliteCommand("select 1 from " + tableName + " where 1 = 0", conn);
                    cmdOthers.ExecuteNonQuery();
                }
                catch
                {
                    exists = false;
                }
            }
            return exists;
        }

    }
}