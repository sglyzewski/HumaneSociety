﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
       

        public static void UpdateAdoption(bool success, ClientAnimalJunction clientAnimalJunction) //void
        {

        }

        public static void UpdateShot(string tyoe, Animal animal) //void
        {

        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates) //void
        {

        }

        public static void GetShots(Animal animal) //var shots ---List<string> shotInfo
        {

        }

        public static void RemoveAnimal(Animal animal) //void
        {

        }

        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state) //void
        {

        }
        public static void UpdateClient(Client client) //void
        {

        }

        public static void UpdateUsername(Client client) //void
        {

        }
        public static void UpdateEmail(Client client) //void
        {

        }
        public static void UpdateAddress(Client client) //void
        {

        }
        public static void UpdateFirstName(Client client) //void
        {

        }

        public static void UpdateLastName(Client client) //void
        {

        }

        public static void GetPendingAdoptions() //var adoptions
        {

        }

        public static void Adopt(Animal animal, Client client)
        {

        }

        public static void RunEmployeeQueries(Employee employee, string update)
        {

        }

        public static Client GetClient(string userName, string password) //client
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var clients =
                from c in context.Clients
                where c.userName == userName && c.pass == password
                select c;
           
            return clients;
           
        }

        public static void GetUserAdoptionStatus(Client client) //var pendingAdoptions
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var approval =
                from c in context.ClientAnimalJunctions
                where c.client == client.ID
                select c.approvalStatus;



        }

        public static void GetAnimalByID(int iD) //Animal or var animal
        {

        }

        public static void RetrieveClients() { } // var clients

        public static void GetBreed() { } //System.Nullable<int> animal.breed

        public static void GetDiet() { } //System.Nullable<int> animal.diet

        public static void GetLocation() { } //System.Nullable<int> animal.location
        public static void AddAnimal(Animal animal) { } //void

        public static void EmployeeLogin(string username, string password) { } //Employee UserEmployee

        public static void RetrieveEmployeeUser(string email, int employeeNumber) { } //Employee

        public static void AddUsernameAndPassword(Employee employee) { } //void

        public static void CheckEmployeeUserNameExist(String username) { } //bool doesExist

        public static void GetStates() { }//var states of string states




    }
}
