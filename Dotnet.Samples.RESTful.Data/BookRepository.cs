using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Transactions;


namespace Dotnet.Samples.RESTful.Data
{
    /// <remarks>
    /// TODO: Refactor this implementation, consider the following approach:
    /// http://rob.conery.io/2014/03/04/repositories-and-unitofwork-are-not-a-good-idea/
    /// </remarks>
    public class BookRepository : IRepository<Book>
    {
        protected readonly DbContext Context; // Repository
        protected readonly DbSet<Book> Set; // Unit of Work

        public BookRepository(DbContext context)
        {
            this.Context = context;
            this.Set = this.Context.Set<Book>();
        }

        public virtual void Create(Book book)
        {
            this.Set.Add(book);
            this.Context.SaveChanges();
        }

        public virtual Book Retrieve(params object[] keyValues)
        {
            return this.Set.Find(keyValues);
        }

        public virtual IList<Book> Retrieve()
        {
            return this.Set as IList<Book>;
        }

        public IList<Book> Retrieve(Expression<Func<Book, bool>> predicate)
        {
            var query = this.Set as IQueryable<Book>;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query as IList<Book>;
        }

        public virtual void Update(Book book)
        {
            this.Context.Entry(book).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public virtual void Delete(params object[] keyValues)
        {
            var entity = this.Set.Find(keyValues);

            if (entity != null)
            {
                this.Set.Remove(entity);
                this.Context.SaveChanges();
            }
        }

    }
}
