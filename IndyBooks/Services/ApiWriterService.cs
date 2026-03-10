#nullable enable
using IndyBooks.Models;

namespace IndyBooks.Services;
public class ApiWriterService : IWriterService
{
    private IndyBooksDataContext _db;
    public ApiWriterService(IndyBooksDataContext db) { _db = db; }
   
    public List<Writer> GetWriterList()
    {
        return _db.Writers.ToList();
    }
    public Writer? GetWriterById(long id)
    {
        return _db.Writers.SingleOrDefault(w=>w.Id == id); //Uses lamda function and extension methods here
    }
    public Writer DeleteWriterById(long id)
    {
        //TODO: Get the Writer at the given id from the db context
        var writer = _db.Writers.SingleOrDefault(w=>w.Id == id);

        //     Remove the Writer at that id, be sure to SaveChanges()
        _db.Writers.Remove(writer);
        _db.SaveChanges();

        return new Writer{ Name = writer.Name, Id = writer.Id}; //TODO: return the deleted Writer info
    }
    public long PostWriter(Writer writer)
    {
        //TODO : Add a new Writer to the db context, return the writer id
        _db.Writers.Add(writer);
        _db.SaveChanges();
        return writer.Id;
    }
    public Writer PutWriter(Writer writer, long id)
    {
        //TODO: Update the Writer at the given id, return the Writer

        _db.Writers.FirstOrDefault(w => w.Id == id).Name = writer.Name;
        _db.SaveChanges();
        return new Writer { Name = writer.Name, Id = id };
    }
}
