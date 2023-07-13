using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;


namespace TP_DB_ELECCIONES;

static public class BD{
    
    private static string _connectionString = @"Server=localhost;
    DataBase=DB_ELECCIONES;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato can) {
    string SQL = "INSERT INTO Candidatos(IdPartido,Apellido,Nombre,FechaNacimiento,Foto,Postulacion) VALUES(@pIdPartido,@pApellido,@pNombre,@pFechaNacimiento,@pFoto, @pPostulacion)";
    using(SqlConnection db = new SqlConnection(_connectionString)){
    db.Execute(SQL, new {pIdPartido = can.IdPartido,pApellido = can.Apellido,pNombre = can.Nombre,pFechaNacimiento = can.FechaNacimiento,pFoto = can.Foto,pPostulacion = can.Postulacion});
    }
    }
    public static void EliminarCandidato(int idCandidato) {
        string SQL = "DELETE FROM Candidatos WHERE idCandidato = @IdCandidato";
        using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(SQL, new {IdCandidato = idCandidato});
    }
}
   public static Partido VerInfoPartido(int idPartido) {
        string SQL = "SELECT * FROM Partidos WHERE idPartido = @IdPartido";
        using(SqlConnection db = new SqlConnection(_connectionString)){
        Partido unPartido = db.QueryFirstOrDefault<Partido>(SQL, new {idPartido = idPartido});
        return unPartido;
    }
   }

     public static Candidato VerInfoCandidatos(int idCandidato) {
        string SQL = "SELECT * FROM Candidatos WHERE idCandidato = @IdCandidato";
        using(SqlConnection db = new SqlConnection(_connectionString)){
        Candidato unCandidato = db.QueryFirstOrDefault<Candidato>(SQL, new {idCandidato = idCandidato});
        return unCandidato;
    }
     }
     public static List<Partido> ListarPartidos() {
        List<Partido> ListaPartidos = new List<Partido>();
        string SQL = "SELECT * FROM Partidos";
        using(SqlConnection db = new SqlConnection(_connectionString)){
        ListaPartidos = db.Query<Partido>(SQL).ToList();
        return ListaPartidos;
    }
     }
     public static List<Candidato> ListarCandidatos(int idPartido) {
        List<Candidato> ListaCandidatos = new List<Candidato>();
        string SQL = "SELECT * FROM Candidatos WHERE IdPartido = @pIdPartido";
        using(SqlConnection db = new SqlConnection(_connectionString)){
        ListaCandidatos = db.Query<Candidato>(SQL, new{pIdPartido = idPartido}).ToList();
        return ListaCandidatos;
    }
}
}


