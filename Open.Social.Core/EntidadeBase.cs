using System;

namespace Open.Social.Core
{
    public class EntidadeBase
    {
        public Guid id { get; set; }

        //public bool ValidData { get; set; }

        //public int CodData { get; set; }

        //public string Message { get; set; }

        //public override bool Equals(object obj)
        //{
        //    // Se for nulo, já retorna falso
        //    if (obj == null)
        //        return false;

        //    // Se não puder fazer o cast para EntidadeBase,
        //    // falso também
        //    var entidade = obj as EntidadeBase;
        //    if (entidade == null)
        //        return false;

        //    // Se o Id for igual a zero, é uma nova entidade,
        //    // nesse caso verificar se é a mesma referencia em memória
        //    if (entidade.id == Guid.TryParse('00000000 - 0000 - 0000 - 0000 - 000000000000') && id == 0)
        //        return ReferenceEquals(this, entidade);

        //    // Agora Returna true se o Id for o mesmo
        //    // para entidades do mesmo tipo
        //    return (id == entidade.id && GetType() == entidade.GetType());
        //}

        //public override Guid GetHashCode()
        //{
        //    return id.GetHashCode();
        //}
    }
}
