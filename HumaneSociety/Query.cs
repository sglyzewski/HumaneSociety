using System;
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

        public static void UpdateShot(string typeOfShot, Animal animal) //void
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animalShotID = (from a in context.AnimalShotJunctions where a.Animal_ID == animal.ID select a.Shot_ID).First();
            Shot shotResult = (from s in context.Shots where s.ID == animalShotID select s).First();
            shotResult.name = typeOfShot;
            context.SubmitChanges();
        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates) //void
        {

        }

        public static List<AnimalShotJunction> GetShots(Animal animal) //var shots ---List<string> shotInfo
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var shots = (from s in context.AnimalShotJunctions where s.Animal_ID == animal.ID select s).ToList();
            return shots;
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

      

        public static void Adopt(Animal animal, Client client)
        {

        }

        public static void RunEmployeeQueries(Employee employee, string update)
        {

        }

        public static Client GetClient(string userName, string password) //client
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var client =
                (from c in context.Clients
                where c.userName == userName && c.pass == password
                select c).FirstOrDefault();
           

            return client;
           
        }

        public static List<ClientAnimalJunction> GetUserAdoptionStatus(Client client) //var pendingAdoptions
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var pendingAdoptions =
                (from c in context.ClientAnimalJunctions
                 where c.client == client.ID 
                 select c).ToList();

            return pendingAdoptions;
        }

        public static List<ClientAnimalJunction> GetPendingAdoptions()
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var pendingAdoptions = (from c in context.ClientAnimalJunctions
                                     
                                     select c).ToList();
            return pendingAdoptions;
        }

        public static Animal GetAnimalByID(int iD) //Animal or var animal
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animal = (
                from a in context.Animals
                where a.ID == iD
                select a).FirstOrDefault();
            return animal;

        }

        public static List<Client> RetrieveClients() {

            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var clients = (from c in context.Clients where (c.ID >= 0) select c).ToList();
            return clients;
        } // var clients

        public static int GetBreed(Animal animal) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var breed = (from b in context.Breeds where animal.breed == b.ID select b.ID).FirstOrDefault();
            return breed;
        } //System.Nullable<int> animal.breed 


        public static int GetDiet(Animal animal) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var diet = (from d in context.DietPlans where animal.diet == d.ID select d.ID).FirstOrDefault();
            return diet;
        } //System.Nullable<int> animal.diet

        public static int GetLocation(Animal animal) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var location = (from r in context.Rooms where animal.location == r.ID select r.ID).FirstOrDefault();
            return location;
        } //System.Nullable<int> animal.location
        public static void AddAnimal(Animal animal) { } //void

        public static Employee EmployeeLogin(string username, string password) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var employee = (from e in context.Employees where (e.userName == username) && e.pass==password select e).FirstOrDefault();
            return employee;
        } //Employee UserEmployee

        public static Employee RetrieveEmployeeUser(string email, int employeeNumber) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var employee = (from e in context.Employees where (e.email == email) && e.employeeNumber == employeeNumber select e).FirstOrDefault();
            return employee;
        } //Employee

        public static void AddUsernameAndPassword(Employee employee) { } //void

        public static bool CheckEmployeeUserNameExist(String username) //bool doesExist
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var usersWithUserName = context.Clients.Where(c => c.userName == username).Select(c => c).FirstOrDefault();
            return (usersWithUserName == null) ? false : true;
    
        } 

        public static List<USState> GetStates() {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var states = (from s in context.USStates select s).ToList();
            return states;
        }//var states of string states




    }
}
