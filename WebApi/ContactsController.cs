using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Common;

namespace WebApi
{
    
    public class ContactsController : ApiController
    {
        static List<Contact> contacts;

        static ContactsController()
        {
            contacts = new List<Contact>();
            contacts.Add(new Contact
            {
                Id = "001",
                Name = "张三",
                PhoneNo = "0513-123456",
                Email = "9635262@qq.com",
                Address = "浙江省杭州市西湖区西湖国际大厦a座"
            });

            contacts.Add(new Contact
            {
                Id = "002",
                Name = "小明",
                PhoneNo = "0513-654321",
                Email = "7599746@qq.com",
                Address = "浙江省杭州市西湖区蒋村电信大楼"
            });
        }

        public IEnumerable<Contact> Get(string id = null)
        {
            return from contact in contacts
                   where contact.Id == id || string.IsNullOrEmpty(id)
                   select contact;
        }

        public void Post(Contact contact)
        {
            contact.Id = "D3";
            contacts.Add(contact);
        }

        public void Put(Contact contact)
        {
            contacts.Remove(contacts.First(c => c.Id == contact.Id));
            contacts.Add(contact);
        }

        public void Delete(string id)
        {
            contacts.Remove(contacts.First(c => c.Id == id));
        }
    }
}
