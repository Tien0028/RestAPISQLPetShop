using PetShopApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApplicationSolution.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetShopApplicationContext ptx)
        {

            // Delete the database, if it already exists. I do this because an
            // existing database may not be compatible with the entity model,
            // if the entity model was changed since the database was created.
            // This operation has no effect for an in-memory database.
            ptx.Database.EnsureDeleted();

            // Create the database, if it does not already exists. This operation
            // has no effect for an in-memory database.
            ptx.Database.EnsureCreated();

            List<PetType> allTypes = new List<PetType>();

            List<PetType> allPetTypes = new List<PetType>
            {
                new PetType {NameOfPetTypes = "Dog"},
                new PetType {NameOfPetTypes = "Cat"},
                new PetType {NameOfPetTypes = "Snake"},
                new PetType {NameOfPetTypes = "Hawk"},
                new PetType {NameOfPetTypes = "Lion"},
                new PetType {NameOfPetTypes = "Goat"},
                new PetType {NameOfPetTypes = "Lizard"},
                new PetType {NameOfPetTypes = "Rabbit"},
                new PetType {NameOfPetTypes = "Dragon"},
                new PetType {NameOfPetTypes = "Turtle"}
            };
            foreach (var petType in allPetTypes)
            {
                var theType = ptx.Add(petType).Entity;
                allTypes.Add(theType);
            }
            //ptx.SaveChanges();

            List<Owner> allTheOwners = new List<Owner>();
            List<Owner> allOwners = new List<Owner>
            {
                new Owner {FirstName ="Jack", LastName = "Davidson", Address = "Deadwell 3, 6600 Vejen",
                    PhoneNumber = "3333 44444", Email = "jack@hotmail.com"},
                new Owner {FirstName ="Peter", LastName = "Parker", Address = "Pride 69, 6969 Someplace",
                    PhoneNumber = "6969 6969", Email = "peter@hmail.com"},
                new Owner {FirstName ="Clark", LastName = "Kent", Address = "Shittington 3, Smallville",
                    PhoneNumber = "DC Comics 45", Email = "Superman@justicemail.com"},
                new Owner {FirstName ="Tony", LastName = "Stark", Address = "ExpensivePlace 4, Malibu State",
                    PhoneNumber = "I AM IRONMAN 10", Email = "tonyStark@avengers.mail"},
                new Owner {FirstName ="Steve", LastName = "Rogers", Address = "Brooklyn 4, 1918",
                    PhoneNumber = "America 5504", Email = "capAmerica@avngers.mail"},
                new Owner {FirstName ="Natasha", LastName = "Romanoff", Address = "Red Room, Russia",
                    PhoneNumber = "0000 0000", Email = "RedWidow@SHIELDmail.com"},
                new Owner {FirstName ="Bruce", LastName = "Wayne", Address = "Wayne Manor, Gotham City",
                    PhoneNumber = "1234 5678", Email = "Batman@justicemail.com"},
                new Owner {FirstName ="Arthur", LastName = "Curry", Address = "Coral Reef, Atlantis",
                    PhoneNumber = "9012 3456", Email = "Aquaman@justicemail.com"}
            };

            foreach (var owner in allOwners)
            {
                var theOwner = ptx.Add(owner).Entity;
                allTheOwners.Add(theOwner);
            }

            List<PetColor> theColors = new List<PetColor>();
            List<PetColor> petColors = new List<PetColor>
            {
                new PetColor{NameOfPetColor = "Red"},
                new PetColor{NameOfPetColor = "Yellow"},
                new PetColor{NameOfPetColor = "Orange"},
                new PetColor{NameOfPetColor = "Green"},
                new PetColor{NameOfPetColor = "Blue"},
                new PetColor{NameOfPetColor = "Indigo"},
                new PetColor{NameOfPetColor = "Violet"}
            };
            foreach (var color in petColors)
            {
                var thecolor = ptx.Add(color).Entity;
                theColors.Add(thecolor);
            }

            
            List<Pet> pets = new List<Pet>
            {
                new Pet{Name = "Dante", Birthdate = new DateTime(2013, 7, 8), SoldDate = new DateTime(2014, 7, 8),
                    previousOwner = "Uriel Sorensson", Price = 250, PetType = allPetTypes[0], PetOwner = allOwners[0], PetColor = new List<PetColorPet> { new PetColorPet { PetColor = petColors[0]}}},

                new Pet{Name = "Vergil", Birthdate = new DateTime(2015, 2, 4), SoldDate = new DateTime(2016, 2, 4),
                    previousOwner = "Bruce Wayne", Price = 750, PetType = allPetTypes[1], PetOwner = allOwners[1], PetColor = new List<PetColorPet> { new PetColorPet { PetColor = petColors[1]}}},
                new Pet{Name = "Lady", Birthdate = new DateTime(2014, 5, 2), SoldDate = new DateTime(2016, 2, 4),
                    previousOwner = "Loki Odinson", Price = 360, PetType = allPetTypes[2], PetOwner = allOwners[2], PetColor = new List<PetColorPet> { new PetColorPet { PetColor = petColors[2]}}},
                new Pet{Name = "Trish", Birthdate = new DateTime(2012, 6, 4), SoldDate = new DateTime(2012, 7, 3),
                    previousOwner = "Urizen Sparkles", Price = 70, PetType = allPetTypes[3], PetOwner = allOwners[3], PetColor = new List<PetColorPet> { new PetColorPet { PetColor = petColors[3]}}},
                new Pet{Name = "Irish", Birthdate = new DateTime(2011, 4, 6), SoldDate = new DateTime(2013, 3, 1),
                    previousOwner = "Simba", Price = 120, PetType = allPetTypes[4], PetOwner = allOwners[4], PetColor = new List<PetColorPet> { new PetColorPet { PetColor = petColors[4]}}},
                new Pet{Name = "Barry", Birthdate = new DateTime(1920, 4, 6), SoldDate = new DateTime(2018, 3, 1),
                    previousOwner = "Henry Allen", Price = 30, PetType = allPetTypes[5], PetOwner = allOwners[5], PetColor = new List<PetColorPet> { new PetColorPet { PetColor = petColors[5]}}},
                new Pet{Name = "OLiver", Birthdate = new DateTime(1970, 5, 9), SoldDate = new DateTime(2019, 2, 3),
                    previousOwner = "Moira", Price = 306, PetType = allPetTypes[6], PetOwner = allOwners[6], PetColor = new List<PetColorPet> { new PetColorPet { PetColor = petColors[6]}}},
            };

            foreach (var pet in pets)
            {
                ptx.Add(pet);
            }
            ptx.SaveChanges();

            // Create four users with hashed and salted passwords
            List<User> users = new List<User>
            {
                new User{Username = "UserJoe", Password = "1234", IsAdmin = false},
                new User{Username = "AdminAnn", Password = "1234", IsAdmin = true},
                new User{Username = "UserJanet", Password = "5678", IsAdmin = false},
                new User{Username = "AdminAni", Password = "5678", IsAdmin = true},
            };

            foreach (var user in users)
            {
                ptx.Add(user);
            }
            ptx.SaveChanges();


            List<ToDoItem> items = new List<ToDoItem>
            {
                new ToDoItem { IsComplete=true, Name="Make homework"},
                new ToDoItem { IsComplete=false, Name="Sleep"}
            };

            foreach (var item in items)
            {
                ptx.Add(item);
            }
            ptx.SaveChanges();

            //ptx.Database.EnsureDeleted();

            ptx.Pets.AddRange(pets);
            ptx.Owners.AddRange(allOwners);
            ptx.PetTypes.AddRange(allPetTypes);
            ptx.PetColors.AddRange(petColors);
            ptx.Users.AddRange(users);
            ptx.ToDoItems.AddRange(items);
            ptx.SaveChanges();
             
        }
    }
}
