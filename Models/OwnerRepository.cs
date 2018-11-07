//
//  Author:
//    kristijanklepac 
//
//  Copyright (c) 2018, ${CopyrightHolder}
//
//  All rights reserved.
//
//
using System;
using System.Collections.Generic;

namespace webapptesy.Models
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner Get(string OwnerId);
        Owner Add(Owner item);
        void Remove(string ownerId);
        bool Update(Owner item);
    }

    public class OwnerRepository : IOwnerRepository
    {

        public static List<Owner> Owners { get; private set; }

        public Owner Add(Owner item)
        {
            throw new NotImplementedException();
        }

        public Owner Get(string OwnerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> GetAll()
        {
            return Owners;
        }

        public void Remove(string ownerId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Owner item)
        {
            throw new NotImplementedException();
        }
    }

}
