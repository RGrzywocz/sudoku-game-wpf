using MySqlConnector;
using System;
using System.Collections.Generic;

namespace SudokuProjekt.Model
{
    class Database
    {
        static MySqlConnection connection()
        {
            MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder();
            connStrBuilder.UserID = "sudokuproject";
            connStrBuilder.Password = "12345";
            connStrBuilder.Server = "localhost";
            connStrBuilder.Database = "sudokudb";
            connStrBuilder.Port = 3306;
            return new MySqlConnection(connStrBuilder.ToString());
        }

        public static int gameId = 0;
        public static string[] getBoard(int difficulty)
        {
            MySqlConnection connectionToDb = connection();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM boards WHERE difficulty>{difficulty - 1} AND difficulty<{difficulty + 1}", connectionToDb);
            connectionToDb.Open();
            MySqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                int random = new Random().Next(1000);
                for (int i = 0; i < random; i++)
                {
                    dataReader.Read();
                }
                dataReader.Read();
                string[] arrays = { dataReader["puzzle"].ToString(), dataReader["solution"].ToString() };
                gameId = (int)dataReader["id"];
                //MessageBox.Show(dataReader["difficulty"].ToString());
                return arrays;
            }
            else if (true)
            {
                return null;
            }
        }
        public static board[] getBoardTable(int difficulty)
        {
            string[] boardsFromDB = getBoard(difficulty);
            string boardFromDb = boardsFromDB[0];
            string solutionFromDb = boardsFromDB[1];
            int[,] board = new int[9, 9];
            int[,] solution = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = (boardFromDb[i * 9 + j] - '0' > 0) ? boardFromDb[i * 9 + j] - '0' : 0;
                    solution[i, j] = (solutionFromDb[i * 9 + j] - '0' > 0) ? solutionFromDb[i * 9 + j] - '0' : 0;
                }
            }
            board[] game = new board[2] { new board(board), new board(solution, gameId) };
            return game;
        }
        public static void insertGame(int idOfGame, int idOfPlayer, int time)
        {
            MySqlConnection connectionToDb = connection();
            connectionToDb.Open();
            MySqlCommand command = connectionToDb.CreateCommand();
            command.CommandText = "insert into games(board_id, player_id, seconds, date_played) values(@board_id, @player_id, @seconds, @date_played)";
            command.Parameters.AddWithValue("@board_id", idOfGame.ToString());
            command.Parameters.AddWithValue("@player_id", idOfPlayer.ToString());
            command.Parameters.AddWithValue("@seconds", time.ToString());
            command.Parameters.AddWithValue("@date_played", DateTime.Now.ToString("yyyy-MM-dd"));
            command.ExecuteNonQuery();
            connectionToDb.Close();
        }
        public static void insertPlayer(string nick)
        {
            MySqlConnection connectionToDb = connection();
            connectionToDb.Open();
            MySqlCommand command = connectionToDb.CreateCommand();
            command.CommandText = "insert into players(nick) values (@nick)";
            command.Parameters.AddWithValue("@nick", nick);
            command.ExecuteNonQuery();
            connectionToDb.Close();
        }
        public static List<String> getPlayers()
        {
            List<String> players = new List<string>();
            MySqlConnection connectionToDb = connection();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM players", connectionToDb);
            connectionToDb.Open();
            MySqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    players.Add(dataReader["nick"].ToString());
                }
                return players;
            }
            else
            {
                return null;
            }

        }
        
    }
}
