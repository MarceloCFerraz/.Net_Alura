namespace bytebank_ADM.SistemaInterno
{
    //A utilização de interfaces permite a implementação de
    //comportamentos distintos para nossas classes de forma
    //mais flexível. Com a interface definimos um contrato,
    //uma regra que qualquer classe que a implemente seguirá
    //no momento de estabelecer nossos métodos
    //https://cursos.alura.com.br/course/csharp-heranca-implementando-interfaces/task/106300
    public interface IAutenticavel
    {
        public bool Autenticar(string senha);

    }
}