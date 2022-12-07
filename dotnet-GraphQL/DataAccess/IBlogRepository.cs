using dotnet_GraphQL.DataAccess.Models;

namespace dotnet_GraphQL.DataAccess
{
    public interface IBlogRepository
    {
        public List<BlogPost> GetList();
        public BlogPost GetById(int id);
    }
}
