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
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            
            if (success == true)
            {
                clientAnimalJunction.approvalStatus = "approved";
                context.SubmitChanges();
            }
            if(success == false)
            {
                clientAnimalJunction.approvalStatus = "rejected";
                context.SubmitChanges();
            }
        }

        public static void UpdateShot(string typeOfShot, Animal animal) //void
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animalShotID = (from a in context.AnimalShotJunctions where a.Animal_ID == animal.ID select a.Shot_ID).FirstOrDefault();
            Shot shotResult = (from s in context.Shots where s.ID == animalShotID select s).FirstOrDefault();
            shotResult.name = typeOfShot;
            context.SubmitChanges();
        }

        public static int GetCategoryKey(string species)
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var catagoryID = (from c in context.Catagories where c.catagory1 == species select c.ID).FirstOrDefault();
            if (catagoryID < 0)
            {
                Catagory catagory = new Catagory();
                catagory.catagory1 = species;
                context.Catagories.InsertOnSubmit(catagory);

                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return catagory.ID;
            }
            return catagoryID;
        }

        public static int GetBreedKey(string breed)
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var breedID = (from c in context.Breeds where c.breed1 == breed select c.ID).FirstOrDefault();
            if (breedID < 0)
            {
                Breed newBreed = new Breed();
                newBreed.breed1 = breed;
                context.Breeds.InsertOnSubmit(newBreed);
                try
                {
                    context.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return newBreed.ID;
            }
            return breedID;
        }
        public static void UpdateSpecies(Animal animal, string update) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var catagoryID = GetCategoryKey(update);
            var breed = (from b in context.Breeds where b.catagory == catagoryID select b).FirstOrDefault();
            animal.breed = breed.ID;
            //context.Animals.InsertOnSubmit(animal);
            context.SubmitChanges();
        }

        
        public static void UpdateBreed(Animal animal, string update) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var breedID = GetBreedKey(update);
            animal.breed = breedID;
            //context.Animals.InsertOnSubmit(animal);
            context.SubmitChanges();

        }


        public static void UpdateName(Animal animal, string update) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animalInContext = (from a in context.Animals where a.ID == animal.ID select a).FirstOrDefault();
            animalInContext.name = update;
            //context.Animals.InsertOnSubmit(animalInContext);
            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
   
        }
        public static void UpdateAge(Animal animal, string update) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animalInContext = (from a in context.Animals where a.ID == animal.ID select a).FirstOrDefault();
            animalInContext.age = Int32.Parse(update);
            //context.Animals.InsertOnSubmit(animalInContext);
            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void UpdateDemeanor(Animal animal, string update) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animalInContext = (from a in context.Animals where a.ID == animal.ID select a).FirstOrDefault();
            animalInContext.demeanor = update;
            //context.Animals.InsertOnSubmit(animalInContext);
            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void UpdateKidFriendly(Animal animal, string update) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animalInContext = (from a in context.Animals where a.ID == animal.ID select a).FirstOrDefault();
            bool kidFriendly;
            if (update.ToLower()=="yes")
            {
               kidFriendly = true;
            }
            else
            {
                kidFriendly = false;
            }
            animalInContext.kidFriendly = kidFriendly;
            //context.Animals.InsertOnSubmit(animalInContext);
            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void UpdatePetFriendly(Animal animal, string update) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animalInContext = (from a in context.Animals where a.ID == animal.ID select a).FirstOrDefault();
            bool petFriendly;
            if (update.ToLower() == "yes")
            {
                petFriendly = true;
            }
            else
            {
                petFriendly = false;
            }
            animalInContext.petFriendly = petFriendly;
            //context.Animals.InsertOnSubmit(animalInContext);
            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void UpdateWeight(Animal animal, string update) {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animalInContext = (from a in context.Animals where a.ID == animal.ID select a).FirstOrDefault();
            animalInContext.weight = Int32.Parse(update);
            //context.Animals.InsertOnSubmit(animalInContext);
            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates) //void
        {
           
            string species ="";
            updates.TryGetValue(1, out species);
            string breed ="";
            updates.TryGetValue(2, out breed);
            string name="";
            updates.TryGetValue(3, out name);
            string age="";
            updates.TryGetValue(4, out age);
            string demeanor="";
            updates.TryGetValue(5, out demeanor);
            string kidFriendly="";
            updates.TryGetValue(6, out kidFriendly);
            string petFriendly="";
            updates.TryGetValue(7, out petFriendly);
            string weight = "";
            updates.TryGetValue(8, out weight);

            if (species != "")
            {
                UpdateSpecies(animal, species);
            }
            if (breed != "")
            {
                UpdateSpecies(animal, breed);
            }
            if(name !="")
            {
                UpdateName(animal, name);
            }
            if(age != "")
            {
                UpdateAge(animal, name);
            }
            if(demeanor != "")
            {
                UpdateDemeanor(animal, demeanor);
            }
            if(kidFriendly != "")
            {
                UpdateKidFriendly(animal, kidFriendly);
            }
            if (petFriendly != "")
            {
                UpdatePetFriendly(animal, petFriendly);
            }
            if (weight != "")
            {
                UpdateWeight(animal, weight);
            }

        }

        public static List<AnimalShotJunction> GetShots(Animal animal) //var shots ---List<string> shotInfo
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var shots = (from s in context.AnimalShotJunctions where s.Animal_ID == animal.ID select s).ToList();
            return shots;
        }

        public static void RemoveAnimal(Animal animal) //void
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var animalInContext = (from a in context.Animals where a.ID == animal.ID select a).FirstOrDefault();
            context.Animals.DeleteOnSubmit(animalInContext);
            context.SubmitChanges();
        }


        //public static int CreateNewAddress(string streetAddress, int zipCode, int state) { }
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
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            var junction = (from j in context.ClientAnimalJunctions where j.animal == animal.ID && j.client == client.ID select j).FirstOrDefault();
            junction.approvalStatus = "pending";
            var animalInContext = (from a in context.Animals where a.ID == animal.ID select a).FirstOrDefault();
            animalInContext.adoptionStatus = "pending";
            context.ClientAnimalJunctions.InsertOnSubmit(junction);
            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            context.Animals.InsertOnSubmit(animalInContext);
            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

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

        public static int GetBreed() {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            string breedString = UserInterface.GetStringData("breed", "the animal's");
            string species = UserInterface.GetStringData("species", "the animal's");
            int catagoryID = GetSpecies(species);
            var breedKey = (from b in context.Breeds where breedString == b.breed1 && catagoryID == b.catagory select b.ID).FirstOrDefault();
            return breedKey;

        } //System.Nullable<int> animal.breed 

        public static int GetSpecies(string catagory)
        {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            
            var catagoryID = (from c in context.Catagories where catagory == c.catagory1  select c.ID).FirstOrDefault();
            return catagoryID;

        }

        public static int GetDiet() {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            string food= UserInterface.GetStringData("food", "the animal's");
            int amount = UserInterface.GetIntegerData("food amount", "the animal's");
            var diet = (from d in context.DietPlans where food == d.food && amount == d.amount select d.ID).FirstOrDefault();
            return diet;
        } //System.Nullable<int> animal.diet

        public static int GetLocation() {
            HumaneSocietyDataContext context = new HumaneSocietyDataContext();
            string name = UserInterface.GetStringData("room name", "the animal's");
            string building = UserInterface.GetStringData("building", "the animal's");
            var location = (from r in context.Rooms where name == r.name && building == r.building select r.ID).FirstOrDefault();
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
