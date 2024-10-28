namespace TesteConteiners.Data.Models
{
    public class ConteinerEnums
    {
        public enum Tipo : byte
        {
            Vinte = 20,
            Quarenta = 40
        }

        public enum Status : byte
        {
            Cheio = 1,
            Vazio = 2
        }
        public enum Categoria
        {
            Importacao = 'I',
            Exportacao = 'E',
        }
        public enum TipoMovimentacao : byte
        {
            Embarque = 1,
            Descarga = 2, 
            GateIn = 3,
            GateOut = 4,
            Reposicionamento = 5,
            Pesagem = 6,
            Scanner = 7
        }
    }
}
