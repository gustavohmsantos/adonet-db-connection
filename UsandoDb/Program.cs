// 1- Criar Db
// 2- Criar Tabela
// 3- Instalar pacote NuGet: Microsoft.Data.SqlClient

using UsandoDb.Db;
using UsandoDb.Models;

try
{
    var artistaDAL = new ArtistaDAL();

    //var novoArtista = new Artista("Teste", "TesteBio");

    //artistaDAL.Adicionar(novoArtista);

    var listaArtistas = artistaDAL.Listar();

    foreach(var artista in listaArtistas)
    {
        Console.WriteLine(artista.Nome);
    }


} catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}