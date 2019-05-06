namespace Cadastro.Shared.Comandos
{
    public interface IManipuladorComando<T> where T:IComandos
    {
        IResultadoComando manipulador(T comando);
    }
}
