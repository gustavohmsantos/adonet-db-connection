using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoDb.Models
{
    internal class Artista
    {
        public string? Nome { get; set; }
        public string FotoPerfil { get; set; }
        public string Bio { get; set; }
        public int Id { get; set; }

        public Artista(string nome, string bio)
        {
            Nome = nome;
            Bio = bio;
            FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
        }
    }
}
