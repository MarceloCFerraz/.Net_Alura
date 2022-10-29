namespace API_Pacientes.Data.DTO
{
    public class ReadPacienteDTO
    {
        public int PacienteID { get; set; }
        public string Nome { get; set; }
        public int Peso { get; set; }
        public double Altura { get; set; }
        public int Gordura { get; set; }
    }
}
