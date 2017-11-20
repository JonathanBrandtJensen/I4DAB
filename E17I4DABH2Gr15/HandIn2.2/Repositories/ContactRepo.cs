﻿using System.Collections.Generic;
using System.Linq;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.CRUD;

namespace HandIn2._2.Repositories
{
    public class ContactRepo : GenericRepo<Contact>, IContactRepo
    {
        public ContactRepo(ICRUD<Contact> crud) : base(crud)
        {
        }

        public List<Contact> GetAllContacts()
        {
            return _crud.Query().ToList();
        }
    }
}