﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsandoDb.Models;

namespace UsandoDb.Db
{
    internal class ArtistaDAL
    {
        public IEnumerable<Artista> Listar()
        {
            var lista = new List<Artista>();
            using var connection = new Connection().Connect();
            connection.Open();

            string sql = "SELECT * FROM Artistas";
            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string nomeArtista = Convert.ToString(dataReader["Nome"]);
                string bioArtista = Convert.ToString(dataReader["Bio"]);
                int idArtista = Convert.ToInt32(dataReader["Id"]);

                Artista artista = new Artista(nomeArtista, bioArtista)
                {
                    Id = idArtista
                };
                lista.Add(artista);
                
            }

            return lista;
        }

        public void Adicionar(Artista artista)
        {
            using var connection = new Connection().Connect();
            connection.Open();

            string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
            command.Parameters.AddWithValue("@bio", artista.Bio);

            int linhas = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {linhas}");
        }

        public void Atualizar(Artista artista)
        {
            using var connection = new Connection().Connect();
            connection.Open();

            string sql = $"UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@bio", artista.Bio);
            command.Parameters.AddWithValue("@id", artista.Id);

            int linhas = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {linhas}");
        }

        public void Deletar(Artista artista)
        {
            using var connection = new Connection().Connect();
            connection.Open();

            string sql = $"DELETE FROM Artistas WHERE Id = @id";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", artista.Id);

            int linhas = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {linhas}");
        }


    }
}
