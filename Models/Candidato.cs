using System.Collections.Generic;
public class Candidato
{
    public int IdCandidato {get; set;}
    public int IdPartido {get; set;}
    public string Apellido {get; set;}
    public string Nombre {get; set;}
    public DateTime FechaNacimiento {get; set;}
    public string Foto {get; set;}
    public string Postulacion {get; set;}
    public Candidato(int idCandidato, int idPartido, string Apellido, string Nombre, DateTime FechaNacimiento, string Foto, string Postulacion)
    {
        this.IdCandidato = idCandidato;
        this.IdPartido = idPartido;
        this.Apellido = Apellido;
        this.Nombre = Nombre;
        this.FechaNacimiento = FechaNacimiento;
        this.Foto = Foto;
        this.Postulacion = Postulacion;
    }
}