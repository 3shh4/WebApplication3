using WebApplication3;
using WebApplication3.Mappers;

namespace WebApplication3;

using System.Collections.Generic;
using System.Linq;
    
public class EFContactService : IContactService
{
    private readonly AppDbContext _context;

    public EFContactService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(Contact contact)
    {
        var entity = _context.Contacts.Add(ContactMapper.ToEntity(contact));
        _context.SaveChanges();
        return entity.Entity.Id;
    }

    public void Delete(int id)
    {
        var contact = _context.Contacts.Find(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }
    }

    public List<Contact> FindAll()
    {
        return _context.Contacts.Select(c => ContactMapper.FromEntity(c)).ToList();
    }

    public Contact FindById(int id)
    {
        var contact = _context.Contacts.Find(id);
        return contact == null ? null : ContactMapper.FromEntity(contact);
    }

    public void Update(Contact contact)
    {
        var entity = ContactMapper.ToEntity(contact);
        _context.Contacts.Update(entity);
        _context.SaveChanges();
    }
}

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Birth { get; set; }
}