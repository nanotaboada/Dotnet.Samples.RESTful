using Dotnet.Samples.RESTful.Data;
using System.Collections.Generic;

namespace Dotnet.Samples.RESTful.Services
{
    // TODO: Define more illustrative/granular methods, e.g. RetrievePublishedAfter(DateTime date)
    public interface IBookService
    {
        // Create
        void Create(Book book);

        // Retrieve
        Book RetrieveByIsbn(string isbn);
        List<Book> RetrieveAll();
        List<Book> RetrieveAllInStock();

        // Update
        void Update(Book book);

        // Delete
        void Delete(string isbn);

        // Validation
        bool IsValidIsbn(string isbn);
    }
}
