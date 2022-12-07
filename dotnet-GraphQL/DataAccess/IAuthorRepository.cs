using dotnet_GraphQL.DataAccess.Models;

namespace dotnet_GraphQL.DataAccess
{
    public interface IAuthorRepository
    {
        public List<Author> GetList();
        public Author GetById(int id);
        public Task<Author> Create(Author author);
    }
}
