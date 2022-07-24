using CRUDApi.Context;
using CRUDApi.Interface;
using CRUDApi.Model;

namespace CRUDApi.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(CRUDContext context) : base(context) { }
    }
}
