namespace WebApplication3
{
    namespace WebApplication3
    {
        public interface IContactService
        {
            int Add(Contact contact);
            void Delete(int id);
            List<Contact> FindAll();
            Contact FindById(int id);
            void Update(Contact contact);
        }
    }
}