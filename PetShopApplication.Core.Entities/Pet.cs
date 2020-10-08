﻿using System;

namespace PetShopApplication.Core.Entities
{
    public class Pet
    {
        public PetType PetType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        //public enum Type2
        //{
        //    Dog,
        //    Cat,
        //    Snake,
        //    Hawk,
        //    Lion
        //}
        //public Type2 Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string previousOwner { get; set; }
        public Owner PetOwner { get; set; }
        public double Price { get; set; }
        public PetColor PetColor { get; set; }
    }
}
